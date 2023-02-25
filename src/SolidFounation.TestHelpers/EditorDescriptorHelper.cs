using System.Reflection;
using EPiServer.Cms.Shell.UI.ObjectEditing;
using EPiServer.Core;
using EPiServer.Framework.Localization;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Shell.ObjectEditing.EditorDescriptors;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using NSubstitute;

namespace SolidFounation.TestHelpers;

public static class EditorDescriptorHelper
    {
        public static ContentDataMetadata CreateContentDataMetadata(PropertyInfo propertyInfo)
        {
            var categoryList = new CategoryList();
            var metadataHandlerRegistry = new MetadataHandlerRegistry(Array.Empty<EditorDescriptor>(), Array.Empty<IModelAccessorCreator>(), Substitute.For<IEditorDefinitionRepository>());
            var metadataProvider = new ExtensibleMetadataProvider(metadataHandlerRegistry, Substitute.For<LocalizationService>(), Substitute.For<IModelMetadataProvider>(), Substitute.For<IValidationAttributeAdapterProvider>());
            var modelAttributes = ModelAttributes.GetAttributesForProperty(typeof(CategoryList), categoryList.GetType().GetProperty(nameof(categoryList.CategoryType))!);
            var defaultMetadataDetails = new DefaultMetadataDetails(ModelMetadataIdentity.ForProperty(propertyInfo, typeof(CategoryList), typeof(PageData)), modelAttributes);
            var defaultMetadata = new DefaultModelMetadata(Substitute.For<IModelMetadataProvider>(), Substitute.For<ICompositeMetadataDetailsProvider>(), defaultMetadataDetails);

            var metadata = Substitute.For<ContentDataMetadata>(
                defaultMetadata,
                Substitute.For<IValidationAttributeAdapterProvider>(),
                metadataProvider,
                null, null, null
            );
            return metadata;
        }

        public static ContentDataMetadata CreateContentDataMetadata(PropertyInfo propertyInfo, PageData model)
        {
            var metadataHandlerRegistry = new MetadataHandlerRegistry(Array.Empty<EditorDescriptor>(), Array.Empty<IModelAccessorCreator>(), Substitute.For<IEditorDefinitionRepository>());
            var metadataProvider = new ExtensibleMetadataProvider(metadataHandlerRegistry, Substitute.For<LocalizationService>(), Substitute.For<IModelMetadataProvider>(), Substitute.For<IValidationAttributeAdapterProvider>());
            var modelAttributes = ModelAttributes.GetAttributesForType(typeof(PageData));
            var defaultMetadataDetails = new DefaultMetadataDetails(ModelMetadataIdentity.ForProperty(propertyInfo, propertyInfo.GetType(), typeof(PageData)), modelAttributes);
            var defaultMetadata = new DefaultModelMetadata(Substitute.For<IModelMetadataProvider>(), Substitute.For<ICompositeMetadataDetailsProvider>(), defaultMetadataDetails);

            Func<object> modelAccessor = () => { return model; };
            var metadata = Substitute.For<ContentDataMetadata>(
                defaultMetadata,
                Substitute.For<IValidationAttributeAdapterProvider>(),
                metadataProvider,
                null, modelAccessor, null);

            return metadata;
        }

        public static ExtendedMetadata CreateExtendedMetadata<T>(PropertyInfo propertyInfo, T model)
        {
            var metadataHandlerRegistry = new MetadataHandlerRegistry(Array.Empty<EditorDescriptor>(), Array.Empty<IModelAccessorCreator>(), Substitute.For<IEditorDefinitionRepository>());
            var metadataProvider = new ExtensibleMetadataProvider(metadataHandlerRegistry, Substitute.For<LocalizationService>(), Substitute.For<IModelMetadataProvider>(), Substitute.For<IValidationAttributeAdapterProvider>());
            var modelAttributes = ModelAttributes.GetAttributesForType(typeof(T));
            var defaultMetadataDetails = new DefaultMetadataDetails(ModelMetadataIdentity.ForProperty(propertyInfo, propertyInfo.GetType(), typeof(T)), modelAttributes);
            var defaultMetadata = new DefaultModelMetadata(Substitute.For<IModelMetadataProvider>(), Substitute.For<ICompositeMetadataDetailsProvider>(), defaultMetadataDetails);

            Func<object> modelAccessor = () => { return model!; };
            var metadata = Substitute.For<ExtendedMetadata>(
                defaultMetadata,
                Substitute.For<IValidationAttributeAdapterProvider>(),
                metadataProvider,
                null, modelAccessor, null);

            return metadata;
        }

        public static ContentDataMetadata CreateContentDataMetadata(PropertyInfo propertyInfo, Type containerType)
        {
            var categoryList = new CategoryList();
            var metadataHandlerRegistry = new MetadataHandlerRegistry(Array.Empty<EditorDescriptor>(), Array.Empty<IModelAccessorCreator>(), Substitute.For<IEditorDefinitionRepository>());
            var metadataProvider = new ExtensibleMetadataProvider(metadataHandlerRegistry, Substitute.For<LocalizationService>(), Substitute.For<IModelMetadataProvider>(), Substitute.For<IValidationAttributeAdapterProvider>());
            var modelAttributes = ModelAttributes.GetAttributesForProperty(typeof(CategoryList), categoryList.GetType().GetProperty(nameof(categoryList.CategoryType))!);
            var defaultMetadataDetails = new DefaultMetadataDetails(ModelMetadataIdentity.ForProperty(propertyInfo, typeof(CategoryList), containerType), modelAttributes);
            var defaultMetadata = new DefaultModelMetadata(Substitute.For<IModelMetadataProvider>(), Substitute.For<ICompositeMetadataDetailsProvider>(), defaultMetadataDetails);

            var metadata = Substitute.For<ContentDataMetadata>(
                defaultMetadata,
                Substitute.For<IValidationAttributeAdapterProvider>(),
                metadataProvider,
                null, null, null
            );
            return metadata;
        }
    }