using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ShutterstockApiExplorer.Core;
using ShutterstockApiExplorer.Core.Authentication;
using ShutterstockApiExplorer.Core.ErrorResponse;
using ShutterstockApiExplorer.Core.Exceptions;
using ShutterstockApiExplorer.Core.Extensions;
using ShutterstockApiExplorer.Core.Models;
using ShutterstockApiExplorer.Core.Request;
using ShutterstockApiExplorer.Core.Response;
using ShutterstockApiExplorer.Errors;
using ShutterstockApiExplorer.Models;
using ShutterstockApiExplorer.Models.AnyOf;
using ShutterstockApiExplorer.Models.Enums;

namespace ShutterstockApiExplorer.Api;

public sealed class Images
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Images(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Add images to collections
    /// </summary>
    /// <param name="id">Collection ID</param>
    /// <param name="body"></param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="AddImageCollectionItemsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint adds one or more images to a collection by image IDs.
    /// </remarks>
    public Task AddImageCollectionItems(string id, CollectionItemRequest body, CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/images/collections/{id}/items"),
            [new TemplateParam("id", id)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            VoidResponse.Instance,
            AddImageCollectionItemsErrorResponse.Instance,
            [_auth.CustomerAccessCode],
            ct);

    /// <summary>
    /// Run multiple image searches
    /// </summary>
    /// <param name="addedDate">Show images added on the specified date</param>
    /// <param name="addedDateStart">Show images added on or after the specified date</param>
    /// <param name="aspectRatioMin">Show images with the specified aspect ratio or higher, using a positive decimal of the width divided by the height, such as 1.7778 for a 16:9 image</param>
    /// <param name="aspectRatioMax">Show images with the specified aspect ratio or lower, using a positive decimal of the width divided by the height, such as 1.7778 for a 16:9 image</param>
    /// <param name="aspectRatio">Show images with the specified aspect ratio, using a positive decimal of the width divided by the height, such as 1.7778 for a 16:9 image</param>
    /// <param name="addedDateEnd">Show images added before the specified date</param>
    /// <param name="category">Show images with the specified Shutterstock-defined category; specify a category name or ID</param>
    /// <param name="color">Specify either a hexadecimal color in the format '4F21EA' or 'grayscale'; the API returns images that use similar colors</param>
    /// <param name="contributor">Show images with the specified contributor names or IDs, allows multiple</param>
    /// <param name="contributorCountry">Show images from contributors in one or more specified countries, or start with NOT to exclude a country from the search</param>
    /// <param name="fields">Fields to display in the response; see the documentation for the fields parameter in the overview section</param>
    /// <param name="height">(Deprecated; use height_from and height_to instead) Show images with the specified height</param>
    /// <param name="heightFrom">Show images with the specified height or larger, in pixels</param>
    /// <param name="heightTo">Show images with the specified height or smaller, in pixels</param>
    /// <param name="imageType">Show images of the specified type</param>
    /// <param name="language">Set query and result language (uses Accept-Language header if not set)</param>
    /// <param name="license">Show only images with the specified license</param>
    /// <param name="model">Show image results with the specified model IDs</param>
    /// <param name="orientation">Show image results with horizontal or vertical orientation</param>
    /// <param name="peopleModelReleased">Show images of people with a signed model release</param>
    /// <param name="peopleAge">Show images that feature people of the specified age category</param>
    /// <param name="peopleEthnicity">Show images with people of the specified ethnicities, or start with NOT to show images without those ethnicities</param>
    /// <param name="peopleGender">Show images with people of the specified gender</param>
    /// <param name="peopleNumber">Show images with the specified number of people</param>
    /// <param name="region">Raise or lower search result rankings based on the result's relevance to a specified region; you can provide a country code or an IP address from which the API infers a country</param>
    /// <param name="sort">Sort by</param>
    /// <param name="view">Amount of detail to render in the response</param>
    /// <param name="width">(Deprecated; use width_from and width_to instead) Show images with the specified width</param>
    /// <param name="widthFrom">Show images with the specified width or larger, in pixels</param>
    /// <param name="widthTo">Show images with the specified width or smaller, in pixels</param>
    /// <param name="body"></param>
    /// <param name="keywordSafeSearch">Hide results with potentially unsafe keywords</param>
    /// <param name="page">Page number</param>
    /// <param name="perPage">Number of results per page</param>
    /// <param name="safe">Enable or disable safe search</param>
    /// <param name="spellcheckQuery">Spellcheck the search query and return results on suggested spellings</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="BulkImageSearchResults"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="BulkSearchImagesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint runs up to 5 image searches in a single request and returns up to 20 results per search. You can provide global search parameters in the query parameters and override them for each search in the body parameter. The query and body parameters are the same as in the <c>GET /v2/images/search</c> endpoint.
    /// </remarks>
    public Task<BulkImageSearchResults> BulkSearchImages(DateTimeOffset? addedDate,
        DateTimeOffset? addedDateStart,
        double? aspectRatioMin,
        double? aspectRatioMax,
        double? aspectRatio,
        DateTimeOffset? addedDateEnd,
        string? category,
        string? color,
        IReadOnlyList<string>? contributor,
        ContributorCountryModel? contributorCountry,
        string? fields,
        int? height,
        int? heightFrom,
        int? heightTo,
        IReadOnlyList<ImageType1>? imageType,
        Language? language,
        IReadOnlyList<License>? license,
        IReadOnlyList<string>? model,
        Orientation1? orientation,
        bool? peopleModelReleased,
        PeopleAge1? peopleAge,
        IReadOnlyList<PeopleEthnicity1>? peopleEthnicity,
        PeopleGender1? peopleGender,
        int? peopleNumber,
        Region1Model? region,
        Sort4? sort,
        View1? view,
        int? width,
        int? widthFrom,
        int? widthTo,
        IReadOnlyList<SearchImage> body,
        bool? keywordSafeSearch = true,
        int? page = 1,
        int? perPage = 20,
        bool? safe = true,
        bool? spellcheckQuery = true,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/bulk_search/images"),
            [],
            [new Param("added_date", addedDate?.ToDate()),
                new Param("added_date_start", addedDateStart?.ToDate()),
                new Param("aspect_ratio_min", aspectRatioMin),
                new Param("aspect_ratio_max", aspectRatioMax),
                new Param("aspect_ratio", aspectRatio),
                new Param("added_date_end", addedDateEnd?.ToDate()),
                new Param("category", category),
                new Param("color", color),
                new Param("contributor", contributor),
                new Param("contributor_country", contributorCountry),
                new Param("fields", fields),
                new Param("height", height),
                new Param("height_from", heightFrom),
                new Param("height_to", heightTo),
                new Param("image_type", imageType),
                new Param("keyword_safe_search", keywordSafeSearch),
                new Param("language", language),
                new Param("license", license),
                new Param("model", model),
                new Param("orientation", orientation),
                new Param("page", page),
                new Param("per_page", perPage),
                new Param("people_model_released", peopleModelReleased),
                new Param("people_age", peopleAge),
                new Param("people_ethnicity", peopleEthnicity),
                new Param("people_gender", peopleGender),
                new Param("people_number", peopleNumber),
                new Param("region", region),
                new Param("safe", safe),
                new Param("sort", sort),
                new Param("spellcheck_query", spellcheckQuery),
                new Param("view", view),
                new Param("width", width),
                new Param("width_from", widthFrom),
                new Param("width_to", widthTo)],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<BulkImageSearchResults>(),
            BulkSearchImagesErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);

    /// <summary>
    /// Create image collections
    /// </summary>
    /// <param name="body"></param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CollectionCreateResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="CreateImageCollectionError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint creates one or more image collections (lightboxes). To add images to the collections, use <c>POST /v2/images/collections/{id}/items</c>.
    /// </remarks>
    public Task<CollectionCreateResponse> CreateImageCollection(CollectionCreateRequest body,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/images/collections"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<CollectionCreateResponse>(),
            CreateImageCollectionErrorResponse.Instance,
            [_auth.CustomerAccessCode],
            ct);

    /// <summary>
    /// Delete image collections
    /// </summary>
    /// <param name="id">Collection ID</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="DeleteImageCollectionError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint deletes an image collection.
    /// </remarks>
    public Task DeleteImageCollection(string id, CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/images/collections/{id}"),
            [new TemplateParam("id", id)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Delete,
            EmptyBody.Instance,
            VoidResponse.Instance,
            DeleteImageCollectionErrorResponse.Instance,
            [_auth.CustomerAccessCode],
            ct);

    /// <summary>
    /// Remove images from collections
    /// </summary>
    /// <param name="id">Collection ID</param>
    /// <param name="itemId">One or more image IDs to remove from the collection</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="DeleteImageCollectionItemsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint removes one or more images from a collection.
    /// </remarks>
    public Task DeleteImageCollectionItems(string id, IReadOnlyList<string>? itemId, CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/images/collections/{id}/items"),
            [new TemplateParam("id", id)],
            [new Param("item_id", itemId)],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Delete,
            EmptyBody.Instance,
            VoidResponse.Instance,
            DeleteImageCollectionItemsErrorResponse.Instance,
            [_auth.CustomerAccessCode],
            ct);

    /// <summary>
    /// Download images
    /// </summary>
    /// <param name="id">License ID</param>
    /// <param name="body"></param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="Url"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="DownloadImageError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint redownloads images that you have already received a license for. The download links in the response are valid for 8 hours.
    /// </remarks>
    public Task<Url> DownloadImage(string id, RedownloadImage body, CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/images/licenses/{id}/downloads"),
            [new TemplateParam("id", id)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<Url>(),
            DownloadImageErrorResponse.Instance,
            [_auth.CustomerAccessCode],
            ct);

    /// <summary>
    /// Get the details of featured image collections
    /// </summary>
    /// <param name="id">Collection ID</param>
    /// <param name="embed">Which sharing information to include in the response, such as a URL to the collection</param>
    /// <param name="assetHint">Cover image size</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="FeaturedCollection"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetFeaturedImageCollectionError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint gets more detailed information about a featured collection, including its cover image and timestamps for its creation and most recent update. To get the images, use <c>GET /v2/images/collections/featured/{id}/items</c>.
    /// </remarks>
    public Task<FeaturedCollection> GetFeaturedImageCollection(string id,
        Embed3? embed,
        AssetHint? assetHint,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/images/collections/featured/{id}"),
            [new TemplateParam("id", id)],
            [new Param("embed", embed), new Param("asset_hint", assetHint)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<FeaturedCollection>(),
            GetFeaturedImageCollectionErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);

    /// <summary>
    /// Get the contents of featured image collections
    /// </summary>
    /// <param name="id">Collection ID</param>
    /// <param name="page">Page number</param>
    /// <param name="perPage">Number of results per page</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CollectionItemDataList"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetFeaturedImageCollectionItemsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint lists the IDs of images in a featured collection and the date that each was added.
    /// </remarks>
    public Task<CollectionItemDataList> GetFeaturedImageCollectionItems(string id,
        int? page = 1,
        int? perPage = 100,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/images/collections/featured/{id}/items"),
            [new TemplateParam("id", id)],
            [new Param("page", page), new Param("per_page", perPage)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<CollectionItemDataList>(),
            GetFeaturedImageCollectionItemsErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);

    /// <summary>
    /// List featured image collections
    /// </summary>
    /// <param name="embed">Which sharing information to include in the response, such as a URL to the collection</param>
    /// <param name="type">The types of collections to return</param>
    /// <param name="assetHint">Cover image size</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="FeaturedCollectionDataList"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetFeaturedImageCollectionListError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint lists featured collections of specific types and a name and cover image for each collection.
    /// </remarks>
    public Task<FeaturedCollectionDataList> GetFeaturedImageCollectionList(Embed3? embed,
        IReadOnlyList<Type4>? type,
        AssetHint? assetHint,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/images/collections/featured"),
            [],
            [new Param("embed", embed), new Param("type", type), new Param("asset_hint", assetHint)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<FeaturedCollectionDataList>(),
            GetFeaturedImageCollectionListErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);

    /// <summary>
    /// Get details about images
    /// </summary>
    /// <param name="id">Image ID</param>
    /// <param name="language">Language for the keywords and categories in the response</param>
    /// <param name="view">Amount of detail to render in the response</param>
    /// <param name="searchId">The ID of the search that is related to this request</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="Image"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetImageError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint shows information about an image, including a URL to a preview image and the sizes that it is available in.
    /// </remarks>
    public Task<Image> GetImage(string id,
        Language? language,
        View1? view,
        string? searchId,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/images/{id}"),
            [new TemplateParam("id", id)],
            [new Param("language", language), new Param("view", view), new Param("search_id", searchId)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<Image>(),
            GetImageErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);

    /// <summary>
    /// Get the details of image collections
    /// </summary>
    /// <param name="id">Collection ID</param>
    /// <param name="embed">Which sharing information to include in the response, such as a URL to the collection</param>
    /// <param name="shareCode">Code to retrieve a shared collection</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="Collection"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetImageCollectionError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint gets more detailed information about a collection, including its cover image and timestamps for its creation and most recent update. To get the images in collections, use <c>GET /v2/images/collections/{id}/items</c>.
    /// </remarks>
    public Task<Collection> GetImageCollection(string id,
        IReadOnlyList<Embed>? embed,
        string? shareCode,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/images/collections/{id}"),
            [new TemplateParam("id", id)],
            [new Param("embed", embed), new Param("share_code", shareCode)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<Collection>(),
            GetImageCollectionErrorResponse.Instance,
            [_auth.CustomerAccessCode],
            ct);

    /// <summary>
    /// Get the contents of image collections
    /// </summary>
    /// <param name="id">Collection ID</param>
    /// <param name="shareCode">Code to retrieve the contents of a shared collection</param>
    /// <param name="sort">Sort order</param>
    /// <param name="page">Page number</param>
    /// <param name="perPage">Number of results per page</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CollectionItemDataList"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetImageCollectionItemsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint lists the IDs of images in a collection and the date that each was added.
    /// </remarks>
    public Task<CollectionItemDataList> GetImageCollectionItems(string id,
        string? shareCode,
        Sort1? sort,
        int? page = 1,
        int? perPage = 100,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/images/collections/{id}/items"),
            [new TemplateParam("id", id)],
            [new Param("page", page),
                new Param("per_page", perPage),
                new Param("share_code", shareCode),
                new Param("sort", sort)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<CollectionItemDataList>(),
            GetImageCollectionItemsErrorResponse.Instance,
            [_auth.CustomerAccessCode],
            ct);

    /// <summary>
    /// List image collections
    /// </summary>
    /// <param name="embed">Which sharing information to include in the response, such as a URL to the collection</param>
    /// <param name="page">Page number</param>
    /// <param name="perPage">Number of results per page</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CollectionDataList"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetImageCollectionListError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint lists your collections of images and their basic attributes.
    /// </remarks>
    public Task<CollectionDataList> GetImageCollectionList(IReadOnlyList<Embed>? embed,
        int? page = 1,
        int? perPage = 100,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/images/collections"),
            [],
            [new Param("embed", embed), new Param("page", page), new Param("per_page", perPage)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<CollectionDataList>(),
            GetImageCollectionListErrorResponse.Instance,
            [_auth.CustomerAccessCode],
            ct);

    /// <summary>
    /// Get keywords from text
    /// </summary>
    /// <param name="body"></param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="SearchEntitiesResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetImageKeywordSuggestionsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint returns up to 10 important keywords from a block of plain text.
    /// </remarks>
    public Task<SearchEntitiesResponse> GetImageKeywordSuggestions(SearchEntitiesRequest body,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/images/search/suggestions"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<SearchEntitiesResponse>(),
            GetImageKeywordSuggestionsErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);

    /// <summary>
    /// List image licenses
    /// </summary>
    /// <param name="imageId">Show licenses for the specified image ID</param>
    /// <param name="license">Show images that are available with the specified license, such as <c>standard</c> or <c>enhanced</c>; prepending a <c>-</c> sign excludes results from that license</param>
    /// <param name="sort">Sort order</param>
    /// <param name="username">Filter licenses by username of licensee</param>
    /// <param name="startDate">Show licenses created on or after the specified date</param>
    /// <param name="endDate">Show licenses created before the specified date</param>
    /// <param name="downloadAvailability">Filter licenses by download availability</param>
    /// <param name="page">Page number</param>
    /// <param name="perPage">Number of results per page</param>
    /// <param name="teamHistory">Set to true to see license history for all members of your team.</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="DownloadHistoryDataList"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetImageLicenseListError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint lists existing licenses.
    /// </remarks>
    public Task<DownloadHistoryDataList> GetImageLicenseList(string? imageId,
        string? license,
        Sort1? sort,
        string? username,
        DateTimeOffset? startDate,
        DateTimeOffset? endDate,
        DownloadAvailability? downloadAvailability,
        int? page = 1,
        int? perPage = 20,
        bool? teamHistory = false,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/images/licenses"),
            [],
            [new Param("image_id", imageId),
                new Param("license", license),
                new Param("page", page),
                new Param("per_page", perPage),
                new Param("sort", sort),
                new Param("username", username),
                new Param("start_date", startDate?.ToIso8601()),
                new Param("end_date", endDate?.ToIso8601()),
                new Param("download_availability", downloadAvailability),
                new Param("team_history", teamHistory)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<DownloadHistoryDataList>(),
            GetImageLicenseListErrorResponse.Instance,
            [_auth.CustomerAccessCode],
            ct);

    /// <summary>
    /// List images
    /// </summary>
    /// <param name="id">One or more image IDs</param>
    /// <param name="view">Amount of detail to render in the response</param>
    /// <param name="searchId">The ID of the search that is related to this request</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ImageDataList"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetImageListError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint lists information about one or more images, including the available sizes.
    /// </remarks>
    public Task<ImageDataList> GetImageList(IReadOnlyList<string> id,
        View1? view,
        string? searchId,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/images"),
            [],
            [new Param("id", id), new Param("view", view), new Param("search_id", searchId)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ImageDataList>(),
            GetImageListErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);

    /// <summary>
    /// List recommended images
    /// </summary>
    /// <param name="id">Image IDs</param>
    /// <param name="maxItems">Maximum number of results returned in the response</param>
    /// <param name="safe">Restrict results to safe images</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="RecommendationDataList"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetImageRecommendationsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint returns images that customers put in the same collection as the specified image IDs.
    /// </remarks>
    public Task<RecommendationDataList> GetImageRecommendations(IReadOnlyList<string> id,
        int? maxItems = 20,
        bool? safe = true,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/images/recommendations"),
            [],
            [new Param("id", id), new Param("max_items", maxItems), new Param("safe", safe)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<RecommendationDataList>(),
            GetImageRecommendationsErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);

    /// <summary>
    /// Get suggestions for a search term
    /// </summary>
    /// <param name="query">Search term for which you want keyword suggestions</param>
    /// <param name="limit">Limit the number of suggestions</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="Suggestions"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetImageSuggestionsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint provides autocomplete suggestions for partial search terms.
    /// </remarks>
    public Task<Suggestions> GetImageSuggestions(string query, int? limit = 10, CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/images/search/suggestions"),
            [],
            [new Param("query", query), new Param("limit", limit)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<Suggestions>(),
            GetImageSuggestionsErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);

    /// <summary>
    /// List updated images
    /// </summary>
    /// <param name="type">Show images that were added, deleted, or edited; by default, the endpoint returns images that were updated in any of these ways</param>
    /// <param name="startDate">Show images updated on or after the specified date</param>
    /// <param name="endDate">Show images updated before the specified date</param>
    /// <param name="sort">Sort order</param>
    /// <param name="interval">Show images updated in the specified time period, where the time period is an interval (like SQL INTERVAL) such as 1 DAY, 6 HOUR, or 30 MINUTE; the default is 1 HOUR, which shows images that were updated in the hour preceding the request</param>
    /// <param name="page">Page number</param>
    /// <param name="perPage">Number of results per page</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="UpdatedMediaDataList"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint lists images that have been updated in the specified time period to update content management systems (CMS) or digital asset management (DAM) systems. In most cases, use the <c>interval</c> parameter to show images that were updated recently, but you can also use the <c>start_date</c> and <c>end_date</c> parameters to specify a range of no more than three days. Do not use the <c>interval</c> parameter with either <c>start_date</c> or <c>end_date</c>.
    /// </remarks>
    public Task<UpdatedMediaDataList> GetUpdatedImages(IReadOnlyList<Type5>? type,
        DateTimeOffset? startDate,
        DateTimeOffset? endDate,
        Sort1? sort,
        string? interval = "1 HOUR",
        int? page = 1,
        int? perPage = 100,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/images/updated"),
            [],
            [new Param("type", type),
                new Param("start_date", startDate?.ToDate()),
                new Param("end_date", endDate?.ToDate()),
                new Param("interval", interval),
                new Param("page", page),
                new Param("per_page", perPage),
                new Param("sort", sort)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<UpdatedMediaDataList>(),
            RawErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);

    /// <summary>
    /// License images
    /// </summary>
    /// <param name="subscriptionId">Subscription ID to use to license the image</param>
    /// <param name="format">(Deprecated) Image format</param>
    /// <param name="size">Image size</param>
    /// <param name="searchId">Search ID that was provided in the results of an image search</param>
    /// <param name="body"></param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="LicenseImageResultDataList"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="LicenseImagesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint gets licenses for one or more images. You must specify the image IDs in the body parameter and other details like the format, size, and subscription ID either in the query parameter or with each image ID in the body parameter. Values in the body parameter override values in the query parameters. The download links in the response are valid for 8 hours.
    /// </remarks>
    public Task<LicenseImageResultDataList> LicenseImages(string? subscriptionId,
        Format4? format,
        Size8? size,
        string? searchId,
        LicenseImageRequest body,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/images/licenses"),
            [],
            [new Param("subscription_id", subscriptionId),
                new Param("format", format),
                new Param("size", size),
                new Param("search_id", searchId)],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<LicenseImageResultDataList>(),
            LicenseImagesErrorResponse.Instance,
            [_auth.CustomerAccessCode],
            ct);

    /// <summary>
    /// List image categories
    /// </summary>
    /// <param name="language">Language for the keywords and categories in the response</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CategoryDataList"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="ListImageCategoriesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint lists the categories (Shutterstock-assigned genres) that images can belong to.
    /// </remarks>
    public Task<CategoryDataList> ListImageCategories(Language? language, CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/images/categories"),
            [],
            [new Param("language", language)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<CategoryDataList>(),
            ListImageCategoriesErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);

    /// <summary>
    /// List similar images
    /// </summary>
    /// <param name="id">Image ID</param>
    /// <param name="language">Language for the keywords and categories in the response</param>
    /// <param name="view">Amount of detail to render in the response</param>
    /// <param name="page">Page number</param>
    /// <param name="perPage">Number of results per page</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ImageSearchResults"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="ListSimilarImagesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint returns images that are visually similar to an image that you specify.
    /// </remarks>
    public Task<ImageSearchResults> ListSimilarImages(string id,
        Language? language,
        View1? view,
        int? page = 1,
        int? perPage = 20,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/images/{id}/similar"),
            [new TemplateParam("id", id)],
            [new Param("language", language),
                new Param("page", page),
                new Param("per_page", perPage),
                new Param("view", view)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ImageSearchResults>(),
            ListSimilarImagesErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);

    /// <summary>
    /// Rename image collections
    /// </summary>
    /// <param name="id">Collection ID</param>
    /// <param name="body"></param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="RenameImageCollectionError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint sets a new name for an image collection.
    /// </remarks>
    public Task RenameImageCollection(string id, CollectionUpdateRequest body, CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/images/collections/{id}"),
            [new TemplateParam("id", id)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            VoidResponse.Instance,
            RenameImageCollectionErrorResponse.Instance,
            [_auth.CustomerAccessCode],
            ct);

    /// <summary>
    /// Search for images
    /// </summary>
    /// <param name="addedDate">Show images added on the specified date</param>
    /// <param name="addedDateStart">Show images added on or after the specified date</param>
    /// <param name="aspectRatioMin">Show images with the specified aspect ratio or higher, using a positive decimal of the width divided by the height, such as 1.7778 for a 16:9 image</param>
    /// <param name="aspectRatioMax">Show images with the specified aspect ratio or lower, using a positive decimal of the width divided by the height, such as 1.7778 for a 16:9 image</param>
    /// <param name="aspectRatio">Show images with the specified aspect ratio, using a positive decimal of the width divided by the height, such as 1.7778 for a 16:9 image</param>
    /// <param name="aiSearch">Set to true and specify the <c>ai_objective</c> and <c>ai_industry</c> parameters to use AI-powered search; the API returns information about how well images meet the objective for the industry</param>
    /// <param name="aiIndustry">For AI-powered search, specify the industry to target; requires that the <c>ai_search</c> parameter is set to true</param>
    /// <param name="aiObjective">For AI-powered search, specify the goal of the media; requires that the <c>ai_search</c> parameter is set to true</param>
    /// <param name="addedDateEnd">Show images added before the specified date</param>
    /// <param name="category">Show images with the specified Shutterstock-defined category; specify a category name or ID</param>
    /// <param name="color">Specify either a hexadecimal color in the format '4F21EA' or 'grayscale'; the API returns images that use similar colors</param>
    /// <param name="contributor">Show images with the specified contributor names or IDs, allows multiple</param>
    /// <param name="contributorCountry">Show images from contributors in one or more specified countries, or start with NOT to exclude a country from the search</param>
    /// <param name="fields">Fields to display in the response; see the documentation for the fields parameter in the overview section</param>
    /// <param name="height">(Deprecated; use height_from and height_to instead) Show images with the specified height</param>
    /// <param name="heightFrom">Show images with the specified height or larger, in pixels</param>
    /// <param name="heightTo">Show images with the specified height or smaller, in pixels</param>
    /// <param name="imageType">Show images of the specified type</param>
    /// <param name="language">Set query and result language (uses Accept-Language header if not set)</param>
    /// <param name="license">Show only images with the specified license</param>
    /// <param name="model">Show image results with the specified model IDs</param>
    /// <param name="orientation">Show image results with horizontal or vertical orientation</param>
    /// <param name="peopleModelReleased">Show images of people with a signed model release</param>
    /// <param name="peopleAge">Show images that feature people of the specified age category</param>
    /// <param name="peopleEthnicity">Show images with people of the specified ethnicities, or start with NOT to show images without those ethnicities</param>
    /// <param name="peopleGender">Show images with people of the specified gender</param>
    /// <param name="peopleNumber">Show images with the specified number of people</param>
    /// <param name="query">One or more search terms separated by spaces; you can use NOT to filter out images that match a term</param>
    /// <param name="region">Raise or lower search result rankings based on the result's relevance to a specified region; you can provide a country code or an IP address from which the API infers a country</param>
    /// <param name="sort">Sort by</param>
    /// <param name="view">Amount of detail to render in the response</param>
    /// <param name="width">(Deprecated; use width_from and width_to instead) Show images with the specified width</param>
    /// <param name="widthFrom">Show images with the specified width or larger, in pixels</param>
    /// <param name="widthTo">Show images with the specified width or smaller, in pixels</param>
    /// <param name="aiLabelsLimit">For AI-powered search, specify the maximum number of labels to return</param>
    /// <param name="keywordSafeSearch">Hide results with potentially unsafe keywords</param>
    /// <param name="page">Page number</param>
    /// <param name="perPage">Number of results per page</param>
    /// <param name="safe">Enable or disable safe search</param>
    /// <param name="spellcheckQuery">Spellcheck the search query and return results on suggested spellings</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ImageSearchResults"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="SearchImagesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This endpoint searches for images. If you specify more than one search parameter, the API uses an AND condition. Array parameters can be specified multiple times; in this case, the API uses an AND or an OR condition with those values, depending on the parameter. You can also filter search terms out in the <c>query</c> parameter by prefixing the term with NOT. Free API accounts show results only from a limited library of media, not the full Shutterstock media library. Also, the number of search fields they can use in a request is limited.
    /// </remarks>
    public Task<ImageSearchResults> SearchImages(DateTimeOffset? addedDate,
        DateTimeOffset? addedDateStart,
        double? aspectRatioMin,
        double? aspectRatioMax,
        double? aspectRatio,
        bool? aiSearch,
        AiIndustry? aiIndustry,
        AiObjective? aiObjective,
        DateTimeOffset? addedDateEnd,
        string? category,
        string? color,
        IReadOnlyList<string>? contributor,
        ContributorCountryModel? contributorCountry,
        string? fields,
        int? height,
        int? heightFrom,
        int? heightTo,
        IReadOnlyList<ImageType1>? imageType,
        Language? language,
        IReadOnlyList<License>? license,
        IReadOnlyList<string>? model,
        Orientation1? orientation,
        bool? peopleModelReleased,
        PeopleAge1? peopleAge,
        IReadOnlyList<PeopleEthnicity1>? peopleEthnicity,
        PeopleGender1? peopleGender,
        int? peopleNumber,
        string? query,
        Region1Model? region,
        Sort4? sort,
        View1? view,
        int? width,
        int? widthFrom,
        int? widthTo,
        int? aiLabelsLimit = 20,
        bool? keywordSafeSearch = true,
        int? page = 1,
        int? perPage = 20,
        bool? safe = true,
        bool? spellcheckQuery = true,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v2/images/search"),
            [],
            [new Param("added_date", addedDate?.ToDate()),
                new Param("added_date_start", addedDateStart?.ToDate()),
                new Param("aspect_ratio_min", aspectRatioMin),
                new Param("aspect_ratio_max", aspectRatioMax),
                new Param("aspect_ratio", aspectRatio),
                new Param("ai_search", aiSearch),
                new Param("ai_labels_limit", aiLabelsLimit),
                new Param("ai_industry", aiIndustry),
                new Param("ai_objective", aiObjective),
                new Param("added_date_end", addedDateEnd?.ToDate()),
                new Param("category", category),
                new Param("color", color),
                new Param("contributor", contributor),
                new Param("contributor_country", contributorCountry),
                new Param("fields", fields),
                new Param("height", height),
                new Param("height_from", heightFrom),
                new Param("height_to", heightTo),
                new Param("image_type", imageType),
                new Param("keyword_safe_search", keywordSafeSearch),
                new Param("language", language),
                new Param("license", license),
                new Param("model", model),
                new Param("orientation", orientation),
                new Param("page", page),
                new Param("per_page", perPage),
                new Param("people_model_released", peopleModelReleased),
                new Param("people_age", peopleAge),
                new Param("people_ethnicity", peopleEthnicity),
                new Param("people_gender", peopleGender),
                new Param("people_number", peopleNumber),
                new Param("query", query),
                new Param("region", region),
                new Param("safe", safe),
                new Param("sort", sort),
                new Param("spellcheck_query", spellcheckQuery),
                new Param("view", view),
                new Param("width", width),
                new Param("width_from", widthFrom),
                new Param("width_to", widthTo)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ImageSearchResults>(),
            SearchImagesErrorResponse.Instance,
            [new AuthSchemeAny(_auth.Basic, _auth.CustomerAccessCode)],
            ct);
}
