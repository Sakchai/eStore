namespace QNet.Web.Infrastructure.Cache
{
    public static partial class QNetModelCacheDefaults
    {
        /// <summary>
        /// Key for categories on the search page
        /// </summary>
        /// <remarks>
        /// {0} : language id
        /// {1} : roles of the current user
        /// {2} : current store ID
        /// </remarks>
        public static string SearchCategoriesModelKey => "QNet.pres.search.categories-{0}-{1}-{2}";
        public static string SearchCategoriesPrefixCacheKey => "QNet.pres.search.categories";

        /// <summary>
        /// Key for ManufacturerNavigationModel caching
        /// </summary>
        /// <remarks>
        /// {0} : current manufacturer id
        /// {1} : language id
        /// {2} : roles of the current user
        /// {3} : current store ID
        /// </remarks>
        public static string ManufacturerNavigationModelKey => "QNet.pres.manufacturer.navigation-{0}-{1}-{2}-{3}";
        public static string ManufacturerNavigationPrefixCacheKey => "QNet.pres.manufacturer.navigation";

        /// <summary>
        /// Key for VendorNavigationModel caching
        /// </summary>
        public static string VendorNavigationModelKey => "QNet.pres.vendor.navigation";
        public static string VendorNavigationPrefixCacheKey => "QNet.pres.vendor.navigation";

        /// <summary>
        /// Key for caching of a value indicating whether a manufacturer has featured products
        /// </summary>
        /// <remarks>
        /// {0} : manufacturer id
        /// {1} : roles of the current user
        /// {2} : current store ID
        /// </remarks>
        public static string ManufacturerHasFeaturedProductsKey => "QNet.pres.manufacturer.hasfeaturedproducts-{0}-{1}-{2}";
        public static string ManufacturerHasFeaturedProductsPrefixCacheKeyById => "QNet.pres.manufacturer.hasfeaturedproducts-{0}-";

        /// <summary>
        /// Key for list of CategorySimpleModel caching
        /// </summary>
        /// <remarks>
        /// {0} : language id
        /// {1} : comma separated list of customer roles
        /// {2} : current store ID
        /// </remarks>
        public static string CategoryAllModelKey => "QNet.pres.category.all-{0}-{1}-{2}";
        public static string CategoryAllPrefixCacheKey => "QNet.pres.category.all";

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : comma separated list of customer roles
        /// {1} : current store ID
        /// {2} : category ID
        /// </remarks>
        public static string CategoryNumberOfProductsModelKey => "QNet.pres.category.numberofproducts-{0}-{1}-{2}";
        public static string CategoryNumberOfProductsPrefixCacheKey => "QNet.pres.category.numberofproducts";

        /// <summary>
        /// Key for caching of a value indicating whether a category has featured products
        /// </summary>
        /// <remarks>
        /// {0} : category id
        /// {1} : roles of the current user
        /// {2} : current store ID
        /// </remarks>
        public static string CategoryHasFeaturedProductsKey => "QNet.pres.category.hasfeaturedproducts-{0}-{1}-{2}";
        public static string CategoryHasFeaturedProductsPrefixCacheKeyById => "QNet.pres.category.hasfeaturedproducts-{0}-";

        /// <summary>
        /// Key for caching of category breadcrumb
        /// </summary>
        /// <remarks>
        /// {0} : category id
        /// {1} : roles of the current user
        /// {2} : current store ID
        /// {3} : language ID
        /// </remarks>
        public static string CategoryBreadcrumbKey => "QNet.pres.category.breadcrumb-{0}-{1}-{2}-{3}";
        public static string CategoryBreadcrumbPrefixCacheKey => "QNet.pres.category.breadcrumb";

        /// <summary>
        /// Key for caching of subcategories of certain category
        /// </summary>
        /// <remarks>
        /// {0} : category id
        /// {1} : roles of the current user
        /// {2} : current store ID
        /// {3} : language ID
        /// {4} : is connection SSL secured (included in a category picture URL)
        /// </remarks>
        public static string CategorySubcategoriesKey => "QNet.pres.category.subcategories-{0}-{1}-{2}-{3}-{4}-{5}";
        public static string CategorySubcategoriesPrefixCacheKey => "QNet.pres.category.subcategories";

        /// <summary>
        /// Key for caching of categories displayed on home page
        /// </summary>
        /// <remarks>
        /// {0} : roles of the current user
        /// {1} : current store ID
        /// {2} : language ID
        /// {3} : is connection SSL secured (included in a category picture URL)
        /// </remarks>
        public static string CategoryHomepageKey => "QNet.pres.category.homepage-{0}-{1}-{2}-{3}-{4}";
        public static string CategoryHomepagePrefixCacheKey => "QNet.pres.category.homepage";

        /// <summary>
        /// Key for Xml document of CategorySimpleModels caching
        /// </summary>
        /// <remarks>
        /// {0} : language id
        /// {1} : comma separated list of customer roles
        /// {2} : current store ID
        /// </remarks>
        public const string CategoryXmlAllModelKey = "QNet.pres.categoryXml.all-{0}-{1}-{2}";
        public const string CategoryXmlAllPrefixCacheKey = "QNet.pres.categoryXml.all";

        /// <summary>
        /// Key for SpecificationAttributeOptionFilter caching
        /// </summary>
        /// <remarks>
        /// {0} : comma separated list of specification attribute option IDs
        /// {1} : language id
        /// </remarks>
        public static string SpecsFilterModelKey => "QNet.pres.filter.specs-{0}-{1}";
        public static string SpecsFilterPrefixCacheKey => "QNet.pres.filter.specs";

        /// <summary>
        /// Key for ProductBreadcrumbModel caching
        /// </summary>
        /// <remarks>
        /// {0} : product id
        /// {1} : language id
        /// {2} : comma separated list of customer roles
        /// {3} : current store ID
        /// </remarks>
        public static string ProductBreadcrumbModelKey => "QNet.pres.product.breadcrumb-{0}-{1}-{2}-{3}";
        public static string ProductBreadcrumbPrefixCacheKey => "QNet.pres.product.breadcrumb";
        public static string ProductBreadcrumbPrefixCacheKeyById => "QNet.pres.product.breadcrumb-{0}-";

        /// <summary>
        /// Key for ProductTagModel caching
        /// </summary>
        /// <remarks>
        /// {0} : product id
        /// {1} : language id
        /// {2} : comma separated list of customer roles
        /// {3} : current store ID
        /// </remarks>
        public static string ProductTagByProductModelKey => "QNet.pres.producttag.byproduct-{0}-{1}-{2}-{3}";
        public static string ProductTagByProductPrefixCacheKey => "QNet.pres.producttag.byproduct";

        /// <summary>
        /// Key for PopularProductTagsModel caching
        /// </summary>
        /// <remarks>
        /// {0} : language id
        /// {1} : current store ID
        /// </remarks>
        public static string ProductTagPopularModelKey => "QNet.pres.producttag.popular-{0}-{1}";
        public static string ProductTagPopularPrefixCacheKey => "QNet.pres.producttag.popular";

        /// <summary>
        /// Key for ProductManufacturers model caching
        /// </summary>
        /// <remarks>
        /// {0} : product id
        /// {1} : language id
        /// {2} : roles of the current user
        /// {3} : current store ID
        /// </remarks>
        public static string ProductManufacturersModelKey => "QNet.pres.product.manufacturers-{0}-{1}-{2}-{3}";
        public static string ProductManufacturersPrefixCacheKey => "QNet.pres.product.manufacturers";
        public static string ProductManufacturersPrefixCacheKeyById => "QNet.pres.product.manufacturers-{0}-";

        /// <summary>
        /// Key for ProductSpecificationModel caching
        /// </summary>
        /// <remarks>
        /// {0} : product id
        /// {1} : language id
        /// </remarks>
        public static string ProductSpecsModelKey => "QNet.pres.product.specs-{0}-{1}";
        public static string ProductSpecsPrefixCacheKey => "QNet.pres.product.specs";
        public static string ProductSpecsPrefixCacheKeyById => "QNet.pres.product.specs-{0}-";

        /// <summary>
        /// Key for TopicModel caching
        /// </summary>
        /// <remarks>
        /// {0} : topic system name
        /// {1} : language id
        /// {2} : store id
        /// {3} : comma separated list of customer roles
        /// </remarks>
        public static string TopicModelBySystemNameKey => "QNet.pres.topic.details.bysystemname-{0}-{1}-{2}-{3}";
        /// <summary>
        /// Key for TopicModel caching
        /// </summary>
        /// <remarks>
        /// {0} : topic id
        /// {1} : language id
        /// {2} : store id
        /// {3} : comma separated list of customer roles
        /// {4} : show hidden records?
        /// </remarks>
        public static string TopicModelByIdKey => "QNet.pres.topic.details.byid-{0}-{1}-{2}-{3}-{4}";
        /// <summary>
        /// Key for TopicModel caching
        /// </summary>
        /// <remarks>
        /// {0} : topic system name
        /// {1} : language id
        /// {2} : store id
        /// {3} : comma separated list of customer roles
        /// </remarks>
        public static string TopicSenameBySystemName => "QNet.pres.topic.sename.bysystemname-{0}-{1}-{2}-{3}";
        /// <summary>
        /// Key for TopicModel caching
        /// </summary>
        /// <remarks>
        /// {0} : topic system name
        /// {1} : language id
        /// {2} : store id
        /// {3} : comma separated list of customer roles
        /// </remarks>
        public static string TopicTitleBySystemName => "QNet.pres.topic.title.bysystemname-{0}-{1}-{2}-{3}";
        /// <summary>
        /// Key for TopMenuModel caching
        /// </summary>
        /// <remarks>
        /// {0} : language id
        /// {1} : current store ID
        /// {2} : comma separated list of customer roles
        /// </remarks>
        public static string TopicTopMenuModelKey => "QNet.pres.topic.topmenu-{0}-{1}-{2}";
        /// <summary>
        /// Key for TopMenuModel caching
        /// </summary>
        /// <remarks>
        /// {0} : language id
        /// {1} : current store ID
        /// {2} : comma separated list of customer roles
        /// </remarks>
        public static string TopicFooterModelKey => "QNet.pres.topic.footer-{0}-{1}-{2}";
        public static string TopicPrefixCacheKey => "QNet.pres.topic";

        /// <summary>
        /// Key for CategoryTemplate caching
        /// </summary>
        /// <remarks>
        /// {0} : category template id
        /// </remarks>
        public static string CategoryTemplateModelKey => "QNet.pres.categorytemplate-{0}";
        public static string CategoryTemplatePrefixCacheKey => "QNet.pres.categorytemplate";

        /// <summary>
        /// Key for ManufacturerTemplate caching
        /// </summary>
        /// <remarks>
        /// {0} : manufacturer template id
        /// </remarks>
        public static string ManufacturerTemplateModelKey => "QNet.pres.manufacturertemplate-{0}";
        public static string ManufacturerTemplatePrefixCacheKey => "QNet.pres.manufacturertemplate";

        /// <summary>
        /// Key for ProductTemplate caching
        /// </summary>
        /// <remarks>
        /// {0} : product template id
        /// </remarks>
        public static string ProductTemplateModelKey => "QNet.pres.producttemplate-{0}";
        public static string ProductTemplatePrefixCacheKey => "QNet.pres.producttemplate";

        /// <summary>
        /// Key for TopicTemplate caching
        /// </summary>
        /// <remarks>
        /// {0} : topic template id
        /// </remarks>
        public static string TopicTemplateModelKey => "QNet.pres.topictemplate-{0}";
        public static string TopicTemplatePrefixCacheKey => "QNet.pres.topictemplate";

        /// <summary>
        /// Key for bestsellers identifiers displayed on the home page
        /// </summary>
        /// <remarks>
        /// {0} : current store ID
        /// </remarks>
        public static string HomepageBestsellersIdsKey => "QNet.pres.bestsellers.homepage-{0}";
        public static string HomepageBestsellersIdsPrefixCacheKey => "QNet.pres.bestsellers.homepage";

        /// <summary>
        /// Key for "also purchased" product identifiers displayed on the product details page
        /// </summary>
        /// <remarks>
        /// {0} : current product id
        /// {1} : current store ID
        /// </remarks>
        public static string ProductsAlsoPurchasedIdsKey => "QNet.pres.alsopuchased-{0}-{1}";
        public static string ProductsAlsoPurchasedIdsPrefixCacheKey => "QNet.pres.alsopuchased";

        /// <summary>
        /// Key for "related" product identifiers displayed on the product details page
        /// </summary>
        /// <remarks>
        /// {0} : current product id
        /// {1} : current store ID
        /// </remarks>
        public static string ProductsRelatedIdsKey => "QNet.pres.related-{0}-{1}";
        public static string ProductsRelatedIdsPrefixCacheKey => "QNet.pres.related";

        /// <summary>
        /// Key for default product picture caching (all pictures)
        /// </summary>
        /// <remarks>
        /// {0} : product id
        /// {1} : picture size
        /// {2} : isAssociatedProduct?
        /// {3} : language ID ("alt" and "title" can depend on localized product name)
        /// {4} : is connection SSL secured?
        /// {5} : current store ID
        /// </remarks>
        public static string ProductDefaultPictureModelKey => "QNet.pres.product.detailspictures-{0}-{1}-{2}-{3}-{4}-{5}";
        public static string ProductDefaultPicturePrefixCacheKey => "QNet.pres.product.detailspictures";
        public static string ProductDefaultPicturePrefixCacheKeyById => "QNet.pres.product.detailspictures-{0}-";

        /// <summary>
        /// Key for product picture caching on the product details page
        /// </summary>
        /// <remarks>
        /// {0} : product id
        /// {1} : picture size
        /// {2} : value indicating whether a default picture is displayed in case if no real picture exists
        /// {3} : language ID ("alt" and "title" can depend on localized product name)
        /// {4} : is connection SSL secured?
        /// {5} : current store ID
        /// </remarks>
        public static string ProductDetailsPicturesModelKey => "QNet.pres.product.picture-{0}-{1}-{2}-{3}-{4}-{5}";
        public static string ProductDetailsPicturesPrefixCacheKey => "QNet.pres.product.picture";
        public static string ProductDetailsPicturesPrefixCacheKeyById => "QNet.pres.product.picture-{0}-";

        /// <summary>
        /// Key for product reviews caching
        /// </summary>
        /// <remarks>
        /// {0} : product id
        /// {1} : current store ID
        /// </remarks>
        public static string ProductReviewsModelKey => "QNet.pres.product.reviews-{0}-{1}";
        public static string ProductReviewsPrefixCacheKey => "QNet.pres.product.reviews";
        public static string ProductReviewsPrefixCacheKeyById => "QNet.pres.product.reviews-{0}-";

        /// <summary>
        /// Key for product attribute picture caching on the product details page
        /// </summary>
        /// <remarks>
        /// {0} : picture id
        /// {1} : is connection SSL secured?
        /// {2} : current store ID
        /// </remarks>
        public static string ProductAttributePictureModelKey => "QNet.pres.productattribute.picture-{0}-{1}-{2}";
        public static string ProductAttributePicturePrefixCacheKey => "QNet.pres.productattribute.picture";

        /// <summary>
        /// Key for product attribute picture caching on the product details page
        /// </summary>
        /// <remarks>
        /// {0} : picture id
        /// {1} : is connection SSL secured?
        /// {2} : current store ID
        /// </remarks>
        public static string ProductAttributeImageSquarePictureModelKey => "QNet.pres.productattribute.imagesquare.picture-{0}-{1}-{2}";
        public static string ProductAttributeImageSquarePicturePrefixCacheKey => "QNet.pres.productattribute.imagesquare.picture";

        /// <summary>
        /// Key for category picture caching
        /// </summary>
        /// <remarks>
        /// {0} : category id
        /// {1} : picture size
        /// {2} : value indicating whether a default picture is displayed in case if no real picture exists
        /// {3} : language ID ("alt" and "title" can depend on localized category name)
        /// {4} : is connection SSL secured?
        /// {5} : current store ID
        /// </remarks>
        public static string CategoryPictureModelKey => "QNet.pres.category.picture-{0}-{1}-{2}-{3}-{4}-{5}";
        public static string CategoryPicturePrefixCacheKey => "QNet.pres.category.picture";
        public static string CategoryPicturePrefixCacheKeyById => "QNet.pres.category.picture-{0}-";

        /// <summary>
        /// Key for manufacturer picture caching
        /// </summary>
        /// <remarks>
        /// {0} : manufacturer id
        /// {1} : picture size
        /// {2} : value indicating whether a default picture is displayed in case if no real picture exists
        /// {3} : language ID ("alt" and "title" can depend on localized manufacturer name)
        /// {4} : is connection SSL secured?
        /// {5} : current store ID
        /// </remarks>
        public static string ManufacturerPictureModelKey => "QNet.pres.manufacturer.picture-{0}-{1}-{2}-{3}-{4}-{5}";
        public static string ManufacturerPicturePrefixCacheKey => "QNet.pres.manufacturer.picture";
        public static string ManufacturerPicturePrefixCacheKeyById => "QNet.pres.manufacturer.picture-{0}-";

        /// <summary>
        /// Key for vendor picture caching
        /// </summary>
        /// <remarks>
        /// {0} : vendor id
        /// {1} : picture size
        /// {2} : value indicating whether a default picture is displayed in case if no real picture exists
        /// {3} : language ID ("alt" and "title" can depend on localized category name)
        /// {4} : is connection SSL secured?
        /// {5} : current store ID
        /// </remarks>
        public static string VendorPictureModelKey => "QNet.pres.vendor.picture-{0}-{1}-{2}-{3}-{4}-{5}";
        public static string VendorPicturePrefixCacheKey => "QNet.pres.vendor.picture";
        public static string VendorPicturePrefixCacheKeyById => "QNet.pres.vendor.picture-{0}-";

        /// <summary>
        /// Key for cart picture caching
        /// </summary>
        /// <remarks>
        /// {0} : shopping cart item id
        /// P.S. we could cache by product ID. it could increase performance.
        /// but it won't work for product attributes with custom images
        /// {1} : picture size
        /// {2} : value indicating whether a default picture is displayed in case if no real picture exists
        /// {3} : language ID ("alt" and "title" can depend on localized product name)
        /// {4} : is connection SSL secured?
        /// {5} : current store ID
        /// </remarks>
        public static string CartPictureModelKey => "QNet.pres.cart.picture-{0}-{1}-{2}-{3}-{4}-{5}";
        public static string CartPicturePrefixCacheKey => "QNet.pres.cart.picture";

        /// <summary>
        /// Key for home page polls
        /// </summary>
        /// <remarks>
        /// {0} : language ID
        /// {1} : current store ID
        /// </remarks>
        public static string HomepagePollsModelKey => "QNet.pres.poll.homepage-{0}-{1}";
        /// <summary>
        /// Key for polls by system name
        /// </summary>
        /// <remarks>
        /// {0} : poll system name
        /// {1} : language ID
        /// {2} : current store ID
        /// </remarks>
        public static string PollBySystemNameModelKey => "QNet.pres.poll.systemname-{0}-{1}-{2}";
        public static string PollsPrefixCacheKey => "QNet.pres.poll";

        /// <summary>
        /// Key for blog tag list model
        /// </summary>
        /// <remarks>
        /// {0} : language ID
        /// {1} : current store ID
        /// </remarks>
        public static string BlogTagsModelKey => "QNet.pres.blog.tags-{0}-{1}";
        /// <summary>
        /// Key for blog archive (years, months) block model
        /// </summary>
        /// <remarks>
        /// {0} : language ID
        /// {1} : current store ID
        /// </remarks>
        public static string BlogMonthsModelKey => "QNet.pres.blog.months-{0}-{1}";
        public static string BlogPrefixCacheKey => "QNet.pres.blog";
        /// <summary>
        /// Key for number of blog comments
        /// </summary>
        /// <remarks>
        /// {0} : blog post ID
        /// {1} : store ID
        /// {2} : are only approved comments?
        /// </remarks>
        public static string BlogCommentsNumberKey => "QNet.pres.blog.comments.number-{0}-{1}-{2}";
        public static string BlogCommentsPrefixCacheKey => "QNet.pres.blog.comments";

        /// <summary>
        /// Key for home page news
        /// </summary>
        /// <remarks>
        /// {0} : language ID
        /// {1} : current store ID
        /// </remarks>
        public static string HomepageNewsModelKey => "QNet.pres.news.homepage-{0}-{1}";
        public static string NewsPrefixCacheKey => "QNet.pres.news";
        /// <summary>
        /// Key for number of news comments
        /// </summary>
        /// <remarks>
        /// {0} : news item ID
        /// {1} : store ID
        /// {2} : are only approved comments?
        /// </remarks>
        public static string NewsCommentsNumberKey => "QNet.pres.news.comments.number-{0}-{1}-{2}";
        public static string NewsCommentsPrefixCacheKey => "QNet.pres.news.comments";

        /// <summary>
        /// Key for states by country id
        /// </summary>
        /// <remarks>
        /// {0} : country ID
        /// {1} : "empty" or "select" item
        /// {2} : language ID
        /// </remarks>
        public static string StateProvincesByCountryModelKey => "QNet.pres.stateprovinces.bycountry-{0}-{1}-{2}";
        public static string StateProvincesPrefixCacheKey => "QNet.pres.stateprovinces";

        /// <summary>
        /// Key for return request reasons
        /// </summary>
        /// <remarks>
        /// {0} : language ID
        /// </remarks>
        public static string ReturnRequestReasonsModelKey => "QNet.pres.returnrequesreasons-{0}";
        public static string ReturnRequestReasonsPrefixCacheKey => "QNet.pres.returnrequesreasons";

        /// <summary>
        /// Key for return request actions
        /// </summary>
        /// <remarks>
        /// {0} : language ID
        /// </remarks>
        public static string ReturnRequestActionsModelKey => "QNet.pres.returnrequestactions-{0}";
        public static string ReturnRequestActionsPrefixCacheKey => "QNet.pres.returnrequestactions";

        /// <summary>
        /// Key for logo
        /// </summary>
        /// <remarks>
        /// {0} : current store ID
        /// {1} : current theme
        /// {2} : is connection SSL secured (included in a picture URL)
        /// </remarks>
        public static string StoreLogoPath => "QNet.pres.logo-{0}-{1}-{2}";
        public static string StoreLogoPathPrefixCacheKey => "QNet.pres.logo";

        /// <summary>
        /// Key for available languages
        /// </summary>
        /// <remarks>
        /// {0} : current store ID
        /// </remarks>
        public static string AvailableLanguagesModelKey => "QNet.pres.languages.all-{0}";
        public static string AvailableLanguagesPrefixCacheKey => "QNet.pres.languages";

        /// <summary>
        /// Key for available currencies
        /// </summary>
        /// <remarks>
        /// {0} : language ID
        /// {1} : current store ID
        /// </remarks>
        public static string AvailableCurrenciesModelKey => "QNet.pres.currencies.all-{0}-{1}";
        public static string AvailableCurrenciesPrefixCacheKey => "QNet.pres.currencies";

        /// <summary>
        /// Key for caching of a value indicating whether we have checkout attributes
        /// </summary>
        /// <remarks>
        /// {0} : current store ID
        /// {1} : true - all attributes, false - only shippable attributes
        /// </remarks>
        public static string CheckoutAttributesExistKey => "QNet.pres.checkoutattributes.exist-{0}-{1}";
        public static string CheckoutAttributesPrefixCacheKey => "QNet.pres.checkoutattributes";

        /// <summary>
        /// Key for sitemap on the sitemap page
        /// </summary>
        /// <remarks>
        /// {0} : language id
        /// {1} : roles of the current user
        /// {2} : current store ID
        /// </remarks>
        public static string SitemapPageModelKey => "QNet.pres.sitemap.page-{0}-{1}-{2}";
        /// <summary>
        /// Key for sitemap on the sitemap SEO page
        /// </summary>
        /// <remarks>
        /// {0} : sitemap identifier
        /// {1} : language id
        /// {2} : roles of the current user
        /// {3} : current store ID
        /// </remarks>
        public static string SitemapSeoModelKey => "QNet.pres.sitemap.seo-{0}-{1}-{2}-{3}";
        public static string SitemapPrefixCacheKey => "QNet.pres.sitemap";

        /// <summary>
        /// Key for widget info
        /// </summary>
        /// <remarks>
        /// {0} : current customer ID
        /// {1} : current store ID
        /// {2} : widget zone
        /// {3} : current theme name
        /// </remarks>
        public static string WidgetModelKey => "QNet.pres.widget-{0}-{1}-{2}-{3}";
        public static string WidgetPrefixCacheKey => "QNet.pres.widget";

    }
}
