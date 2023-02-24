using EPiServer.Core;
using Microsoft.AspNetCore.Mvc;
using SolidFoundation.Foundation.Foundation.Components.Metadata.Services;
using SolidFoundation.Foundation.Foundation.Models.BaseModels;
using SolidFoundation.Foundation.Foundation.Models.ViewModels;

namespace SolidFoundation.Foundation.Foundation.Components.Metadata;

    public class MetadataViewComponent : ViewComponent
    {
        private readonly IMetadataViewModelFactory _viewModelFactory;

        public MetadataViewComponent(IMetadataViewModelFactory viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(IContentViewModel<IContent> content)
        {
            if (content.CurrentContent is not SitePage sitePage)
            {
                return Content(string.Empty);
            }

            var model = _viewModelFactory.Create(sitePage);

            return await Task.FromResult(View("~/Foundation/Components/Metadata/Default.cshtml", model));
        }
    }