using AccesaQuests.Web.Models.Domain;
using AccesaQuests.Web.Models.ViewsName;
using AccesaQuests.Web.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;

namespace AccesaQuests.Web.Controllers
{
    public class AdminPostsController : Controller
    {
        private readonly ITagRepository tagRepository;
        private readonly IPostRepository postRepository;

        public AdminPostsController(ITagRepository tagRepository , IPostRepository postRepository)
        {
            this.tagRepository = tagRepository;
            this.postRepository = postRepository;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Add()
        {
            //get tags from repository
            var tags = await tagRepository.GetAllAsync();
            var model = new AddPostRequest
            {
                Tags = tags.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() })
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddPostRequest addPostRequest)
        {
            //Map view model to domain model
            var post = new Post
            {
                PostHeading = addPostRequest.PostHeading,
                PostTitle = addPostRequest.PostTitle,
                Content = addPostRequest.Content,
                ShortDescription = addPostRequest.ShortDescription,
                FeaturedImageUrl = addPostRequest.FeaturedImageUrl,
                UrlHandle = addPostRequest.UrlHandle,
                PublishedDate = addPostRequest.PublishedDate,
                Author = addPostRequest.Author,
                Visible = addPostRequest.Visible,
            };
            //Map Tags from selected tags
            var selectedTags = new List<Tag>();
            foreach ( var selectedTagId in addPostRequest.SelectedTags)
            {
                var selectedTagAsGuid = Guid.Parse(selectedTagId);
                var existingTag = await tagRepository.GetAsync(selectedTagAsGuid);

                if(existingTag != null)
                {
                    selectedTags.Add(existingTag);
                }
            }
            //Mapping tags back to domain model
            post.Tags = selectedTags;

            await postRepository.AddAsync(post);

            return RedirectToAction("Add");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> List()
        {
            //call the repository
            var posts = await postRepository.GetAllAsync();    

            return View(posts);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            // Retrive the result from the repository
            var post = await postRepository.GetAsync(id);
            var tagsDomainModel = await tagRepository.GetAllAsync();
            if (post != null)
            {
                //map the domain model into the view model

                var model = new EditPostRequest
                {
                    Id = post.Id,

                    PostHeading = post.PostHeading,
                    PostTitle = post.PostTitle,
                    Content = post.Content,
                    Author = post.Author,
                    FeaturedImageUrl = post.FeaturedImageUrl,
                    UrlHandle = post.UrlHandle,
                    ShortDescription = post.ShortDescription,
                    PublishedDate = post.PublishedDate,
                    Visible = post.Visible,
                    Tags = tagsDomainModel.Select(x => new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.Id.ToString()
                    }),
                    SelectedTags = post.Tags.Select(x => x.Id.ToString()).ToArray(),
                };
                return View(model);
            }
           
            //pass data to view
            return View(null);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditPostRequest editPostRequest)
        {
            //map view model back to domain model
            var postDomainModel = new Post
            {
                Id = editPostRequest.Id,
                PostHeading = editPostRequest.PostHeading,
                PostTitle = editPostRequest.PostTitle,
                Content = editPostRequest.Content,
                ShortDescription = editPostRequest.ShortDescription,
                FeaturedImageUrl = editPostRequest.FeaturedImageUrl,
                PublishedDate = editPostRequest.PublishedDate,
                UrlHandle = editPostRequest.UrlHandle,
                Visible = editPostRequest.Visible,
                Author = editPostRequest.Author,
            };
            //Map tags into domain model
            var selectedTags = new List<Tag>();
                foreach ( var selectedTag in editPostRequest.SelectedTags ) 
                {
                   if(Guid.TryParse(selectedTag, out var tag))
                   {
                     var foundTAG =await tagRepository.GetAsync(tag);

                      if(foundTAG != null)
                       {
                        selectedTags.Add(foundTAG);
                       }
                   }
                }
                postDomainModel.Tags = selectedTags;

            //Submit information to repository to update
            var updatedPost = await postRepository.UpdateAsync(postDomainModel);
            if (updatedPost != null)
            {
                //Show succes notification
                return RedirectToAction("Edit");
            }
            //Show error notification
            //redirect to Get
            return RedirectToAction("Edit");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(EditPostRequest editPostRequest)
        {
            //Talk to repository to delete this posts and tags
            var deletedPost = await postRepository.DeleteAsync(editPostRequest.Id);
            if (deletedPost != null)
            {
                //show succes notification
                return RedirectToAction("List");
            }
            //show error notification
            return RedirectToAction("Edit" ,new { id = editPostRequest.Id});
            //display the response
        }
        
    }
}
