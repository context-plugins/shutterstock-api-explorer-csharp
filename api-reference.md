# Reference

> Source: [ShutterstockApiExplorerClient](ShutterstockApiExplorerClient.cs)

## AudioModel

> Source: [AudioModel](Api/AudioModel.cs)

<details>
<summary><code>Task AddTrackCollectionItems(string id, CollectionItemRequest body, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint adds one or more tracks to a collection by track IDs.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    await client.AudioModel.AddTrackCollectionItems(id, body);
}
catch (SdkException<AddTrackCollectionItemsError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type AddTrackCollectionItemsError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>id</code> | <code>string</code> | Collection ID |
| <code>body</code> | <code>[CollectionItemRequest](Models/CollectionItemRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: No content

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[AddTrackCollectionItemsError](Errors/AddTrackCollectionItemsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CollectionCreateResponse&gt; CreateTrackCollection(CollectionCreateRequest body, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint creates one or more collections (soundboxes). To add tracks, use `POST /v2/audio/collections/{id}/items`.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.AudioModel.CreateTrackCollection(body);
    // TODO: Handle 'response' of type CollectionCreateResponse
}
catch (SdkException<CreateTrackCollectionError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type CreateTrackCollectionError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>body</code> | <code>[CollectionCreateRequest](Models/CollectionCreateRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CollectionCreateResponse](Models/CollectionCreateResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[CreateTrackCollectionError](Errors/CreateTrackCollectionError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task DeleteTrackCollection(string id, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint deletes a collection.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    await client.AudioModel.DeleteTrackCollection(id);
}
catch (SdkException<DeleteTrackCollectionError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type DeleteTrackCollectionError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>id</code> | <code>string</code> | Collection ID |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: No content

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[DeleteTrackCollectionError](Errors/DeleteTrackCollectionError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task DeleteTrackCollectionItems(string id, IReadOnlyList&lt;string&gt;? itemId, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint removes one or more tracks from a collection.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    await client.AudioModel.DeleteTrackCollectionItems(id, itemId);
}
catch (SdkException<DeleteTrackCollectionItemsError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type DeleteTrackCollectionItemsError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>id</code> | <code>string</code> | Collection ID |
| <code>itemId</code> | <code>IReadOnlyList&lt;string&gt;?</code> | One or more item IDs to remove from the collection |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: No content

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[DeleteTrackCollectionItemsError](Errors/DeleteTrackCollectionItemsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;AudioUrl&gt; DownloadTracks(string id, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint redownloads tracks that you have already received a license for. The download links in the response are valid for 8 hours.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.AudioModel.DownloadTracks(id);
    // TODO: Handle 'response' of type AudioUrl
}
catch (SdkException<DownloadTracksError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type DownloadTracksError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>id</code> | <code>string</code> | License ID |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[AudioUrl](Models/AudioUrl.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[DownloadTracksError](Errors/DownloadTracksError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;Audio&gt; GetTrack(int id, View1? view, string? searchId, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint shows information about a track, including its genres, instruments, and other attributes.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.AudioModel.GetTrack(id, view, searchId);
    // TODO: Handle 'response' of type Audio
}
catch (SdkException<GetTrackError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetTrackError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>id</code> | <code>int</code> | Audio track ID |
| <code>view</code> | <code>[View1?](Models/Enums/View1.cs)</code> | Amount of detail to render in the response |
| <code>searchId</code> | <code>string?</code> | The ID of the search that is related to this request |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[Audio](Models/Audio.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetTrackError](Errors/GetTrackError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;Collection&gt; GetTrackCollection(string id, IReadOnlyList&lt;Embed&gt;? embed, string? shareCode, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint gets more detailed information about a collection, including the number of items in it and when it was last updated. To get the tracks in collections, use `GET /v2/audio/collections/{id}/items`.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.AudioModel.GetTrackCollection(id, embed, shareCode);
    // TODO: Handle 'response' of type Collection
}
catch (SdkException<GetTrackCollectionError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetTrackCollectionError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>id</code> | <code>string</code> | Collection ID |
| <code>embed</code> | <code>IReadOnlyList&lt;[Embed](Models/Enums/Embed.cs)&gt;?</code> | Which sharing information to include in the response, such as a URL to the collection |
| <code>shareCode</code> | <code>string?</code> | Code to retrieve a shared collection |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[Collection](Models/Collection.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetTrackCollectionError](Errors/GetTrackCollectionError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CollectionItemDataList&gt; GetTrackCollectionItems(string id, string? shareCode, Sort1? sort, int? page = 1, int? perPage = 100, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint lists the IDs of tracks in a collection and the date that each was added.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.AudioModel.GetTrackCollectionItems(id, shareCode, sort);
    // TODO: Handle 'response' of type CollectionItemDataList
}
catch (SdkException<GetTrackCollectionItemsError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetTrackCollectionItemsError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>id</code> | <code>string</code> | Collection ID |
| <code>shareCode</code> | <code>string?</code> | Code to retrieve the contents of a shared collection |
| <code>sort</code> | <code>[Sort1?](Models/Enums/Sort1.cs)</code> | Sort order |
| <code>page</code> | <code>int?</code> | Page number<br>**Default**: 1 |
| <code>perPage</code> | <code>int?</code> | Number of results per page<br>**Default**: 100 |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CollectionItemDataList](Models/CollectionItemDataList.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetTrackCollectionItemsError](Errors/GetTrackCollectionItemsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CollectionDataList&gt; GetTrackCollectionList(IReadOnlyList&lt;Embed&gt;? embed, int? page = 1, int? perPage = 100, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint lists your collections of audio tracks and their basic attributes.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.AudioModel.GetTrackCollectionList(embed);
    // TODO: Handle 'response' of type CollectionDataList
}
catch (SdkException<GetTrackCollectionListError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetTrackCollectionListError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>embed</code> | <code>IReadOnlyList&lt;[Embed](Models/Enums/Embed.cs)&gt;?</code> | Which sharing information to include in the response, such as a URL to the collection |
| <code>page</code> | <code>int?</code> | Page number<br>**Default**: 1 |
| <code>perPage</code> | <code>int?</code> | Number of results per page<br>**Default**: 100 |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CollectionDataList](Models/CollectionDataList.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetTrackCollectionListError](Errors/GetTrackCollectionListError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;DownloadHistoryDataList&gt; GetTrackLicenseList(string? audioId, string? license, Sort1? sort, string? username, DateTimeOffset? startDate, DateTimeOffset? endDate, DownloadAvailability? downloadAvailability, int? page = 1, int? perPage = 20, bool? teamHistory = false, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint lists existing licenses. You can filter the results according to the track ID to see if you have an existing license for a specific track.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.AudioModel.GetTrackLicenseList(audioId,
        license,
        sort,
        username,
        startDate,
        endDate,
        downloadAvailability);
    // TODO: Handle 'response' of type DownloadHistoryDataList
}
catch (SdkException<GetTrackLicenseListError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetTrackLicenseListError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>audioId</code> | <code>string?</code> | Show licenses for the specified track ID |
| <code>license</code> | <code>string?</code> | Restrict results by license. Prepending a `-` sign will exclude results by license |
| <code>sort</code> | <code>[Sort1?](Models/Enums/Sort1.cs)</code> | Sort order |
| <code>username</code> | <code>string?</code> | Filter licenses by username of licensee |
| <code>startDate</code> | <code>DateTimeOffset?</code> | Show licenses created on or after the specified date |
| <code>endDate</code> | <code>DateTimeOffset?</code> | Show licenses created before the specified date |
| <code>downloadAvailability</code> | <code>[DownloadAvailability?](Models/Enums/DownloadAvailability.cs)</code> | Filter licenses by download availability |
| <code>page</code> | <code>int?</code> | Page number<br>**Default**: 1 |
| <code>perPage</code> | <code>int?</code> | Number of results per page<br>**Default**: 20 |
| <code>teamHistory</code> | <code>bool?</code> | Set to true to see license history for all members of your team.<br>**Default**: false |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[DownloadHistoryDataList](Models/DownloadHistoryDataList.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetTrackLicenseListError](Errors/GetTrackLicenseListError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;AudioDataList&gt; GetTrackList(IReadOnlyList&lt;string&gt; id, View1? view, string? searchId, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint lists information about one or more audio tracks, including the description and publication date.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.AudioModel.GetTrackList(id, view, searchId);
    // TODO: Handle 'response' of type AudioDataList
}
catch (SdkException<GetTrackListError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetTrackListError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>id</code> | <code>IReadOnlyList&lt;string&gt;</code> | One or more audio IDs |
| <code>view</code> | <code>[View1?](Models/Enums/View1.cs)</code> | Amount of detail to render in the response |
| <code>searchId</code> | <code>string?</code> | The ID of the search that is related to this request |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[AudioDataList](Models/AudioDataList.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetTrackListError](Errors/GetTrackListError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;LicenseAudioResultDataList&gt; LicenseTrack(License3? license, string? searchId, LicenseAudioRequest body, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint gets licenses for one or more tracks. The download links in the response are valid for 8 hours.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.AudioModel.LicenseTrack(license, searchId, body);
    // TODO: Handle 'response' of type LicenseAudioResultDataList
}
catch (SdkException<LicenseTrackError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type LicenseTrackError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>license</code> | <code>[License3?](Models/Enums/License3.cs)</code> | License type |
| <code>searchId</code> | <code>string?</code> | The ID of the search that led to licensing this track |
| <code>body</code> | <code>[LicenseAudioRequest](Models/LicenseAudioRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[LicenseAudioResultDataList](Models/LicenseAudioResultDataList.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[LicenseTrackError](Errors/LicenseTrackError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GenreList&gt; ListGenres(string? language, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint returns a list of all audio genres.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.AudioModel.ListGenres(language);
    // TODO: Handle 'response' of type GenreList
}
catch (SdkException<RawError> ex)
{
    // TODO: Handle 'ex.Error' of type RawError
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>language</code> | <code>string?</code> | Which language the genres will be returned |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GenreList](Models/GenreList.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[RawError](Core/ErrorResponse/RawError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;InstrumentList&gt; ListInstruments(string? language, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint returns a list of all audio instruments.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.AudioModel.ListInstruments(language);
    // TODO: Handle 'response' of type InstrumentList
}
catch (SdkException<RawError> ex)
{
    // TODO: Handle 'ex.Error' of type RawError
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>language</code> | <code>string?</code> | Which language the instruments will be returned in |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[InstrumentList](Models/InstrumentList.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[RawError](Core/ErrorResponse/RawError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;MoodList&gt; ListMoods(string? language, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint returns a list of all audio moods.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.AudioModel.ListMoods(language);
    // TODO: Handle 'response' of type MoodList
}
catch (SdkException<RawError> ex)
{
    // TODO: Handle 'ex.Error' of type RawError
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>language</code> | <code>string?</code> | Which language the moods will be returned in |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[MoodList](Models/MoodList.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[RawError](Core/ErrorResponse/RawError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task RenameTrackCollection(string id, CollectionUpdateRequest body, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint sets a new name for a collection.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    await client.AudioModel.RenameTrackCollection(id, body);
}
catch (SdkException<RenameTrackCollectionError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type RenameTrackCollectionError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>id</code> | <code>string</code> | Collection ID |
| <code>body</code> | <code>[CollectionUpdateRequest](Models/CollectionUpdateRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: No content

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[RenameTrackCollectionError](Errors/RenameTrackCollectionError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;AudioSearchResults&gt; SearchTracks(IReadOnlyList&lt;string&gt;? artists, int? bpm, int? bpmFrom, int? bpmTo, int? duration, int? durationFrom, int? durationTo, IReadOnlyList&lt;string&gt;? genre, bool? isInstrumental, IReadOnlyList&lt;string&gt;? instruments, IReadOnlyList&lt;string&gt;? moods, string? query, Sort3? sort, SortOrder? sortOrder, string? vocalDescription, View1? view, string? fields, Library? library, string? language, int? page = 1, int? perPage = 20, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint searches for tracks. If you specify more than one search parameter, the API uses an AND condition. Array parameters can be specified multiple times; in this case, the API uses an AND or an OR condition with those values, depending on the parameter.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.AudioModel.SearchTracks(artists,
        bpm,
        bpmFrom,
        bpmTo,
        duration,
        durationFrom,
        durationTo,
        genre,
        isInstrumental,
        instruments,
        moods,
        query,
        sort,
        sortOrder,
        vocalDescription,
        view,
        fields,
        library,
        language);
    // TODO: Handle 'response' of type AudioSearchResults
}
catch (SdkException<SearchTracksError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type SearchTracksError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>artists</code> | <code>IReadOnlyList&lt;string&gt;?</code> | Show tracks with one of the specified artist names or IDs |
| <code>bpm</code> | <code>int?</code> | (Deprecated; use bpm_from and bpm_to instead) Show tracks with the specified beats per minute |
| <code>bpmFrom</code> | <code>int?</code> | Show tracks with the specified beats per minute or faster |
| <code>bpmTo</code> | <code>int?</code> | Show tracks with the specified beats per minute or slower |
| <code>duration</code> | <code>int?</code> | Show tracks with the specified duration in seconds |
| <code>durationFrom</code> | <code>int?</code> | Show tracks with the specified duration or longer in seconds |
| <code>durationTo</code> | <code>int?</code> | Show tracks with the specified duration or shorter in seconds |
| <code>genre</code> | <code>IReadOnlyList&lt;string&gt;?</code> | Show tracks with each of the specified genres; to get the list of genres, use `GET /v2/audio/genres` |
| <code>isInstrumental</code> | <code>bool?</code> | Show instrumental music only |
| <code>instruments</code> | <code>IReadOnlyList&lt;string&gt;?</code> | Show tracks with each of the specified instruments; to get the list of instruments, use `GET /v2/audio/instruments` |
| <code>moods</code> | <code>IReadOnlyList&lt;string&gt;?</code> | Show tracks with each of the specified moods; to get the list of moods, use `GET /v2/audio/moods` |
| <code>query</code> | <code>string?</code> | One or more search terms separated by spaces |
| <code>sort</code> | <code>[Sort3?](Models/Enums/Sort3.cs)</code> | Sort by |
| <code>sortOrder</code> | <code>[SortOrder?](Models/Enums/SortOrder.cs)</code> | Sort order |
| <code>vocalDescription</code> | <code>string?</code> | Show tracks with the specified vocal description (male, female) |
| <code>view</code> | <code>[View1?](Models/Enums/View1.cs)</code> | Amount of detail to render in the response |
| <code>fields</code> | <code>string?</code> | Fields to display in the response; see the documentation for the fields parameter in the overview section |
| <code>library</code> | <code>[Library?](Models/Enums/Library.cs)</code> | Which library to search |
| <code>language</code> | <code>string?</code> | Which language to search in |
| <code>page</code> | <code>int?</code> | Page number<br>**Default**: 1 |
| <code>perPage</code> | <code>int?</code> | Number of results per page<br>**Default**: 20 |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[AudioSearchResults](Models/AudioSearchResults.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[SearchTracksError](Errors/SearchTracksError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Catalog

> Source: [Catalog](Api/Catalog.cs)

<details>
<summary><code>Task&lt;CatalogCollection&gt; AddToCollection(string collectionId, CreateCatalogCollectionItems body, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint adds assets to a catalog collection. It also automatically adds the assets to the user's account's catalog.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Catalog.AddToCollection(collectionId, body);
    // TODO: Handle 'response' of type CatalogCollection
}
catch (SdkException<RawError> ex)
{
    // TODO: Handle 'ex.Error' of type RawError
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>collectionId</code> | <code>string</code> | The ID of the collection to add assets to |
| <code>body</code> | <code>[CreateCatalogCollectionItems](Models/CreateCatalogCollectionItems.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CatalogCollection](Models/CatalogCollection.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[RawError](Core/ErrorResponse/RawError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CatalogCollection&gt; CreateCollection(CreateCatalogCollection body, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint creates a catalog collection and optionally adds assets. To add assets to the collection later, use `PATCH /v2/catalog/collections/{collection_id}/items`.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Catalog.CreateCollection(body);
    // TODO: Handle 'response' of type CatalogCollection
}
catch (SdkException<RawError> ex)
{
    // TODO: Handle 'ex.Error' of type RawError
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>body</code> | <code>[CreateCatalogCollection](Models/CreateCatalogCollection.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CatalogCollection](Models/CatalogCollection.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[RawError](Core/ErrorResponse/RawError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task DeleteCollection(string collectionId, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint deletes a catalog collection. It does not remove the assets from the user's account's catalog.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    await client.Catalog.DeleteCollection(collectionId);
}
catch (SdkException<DeleteCollectionError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type DeleteCollectionError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>collectionId</code> | <code>string</code> | The ID of the collection to delete |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: No content

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[DeleteCollectionError](Errors/DeleteCollectionError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CatalogCollection&gt; DeleteFromCollection(string collectionId, RemoveCatalogCollectionItems body, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint removes assets from a catalog collection. It does not remove the assets from the user's account's catalog.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Catalog.DeleteFromCollection(collectionId, body);
    // TODO: Handle 'response' of type CatalogCollection
}
catch (SdkException<RawError> ex)
{
    // TODO: Handle 'ex.Error' of type RawError
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>collectionId</code> | <code>string</code> | The ID of the collection to remove assets from |
| <code>body</code> | <code>[RemoveCatalogCollectionItems](Models/RemoveCatalogCollectionItems.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CatalogCollection](Models/CatalogCollection.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[RawError](Core/ErrorResponse/RawError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CatalogCollectionDataList&gt; GetCollections(Sort1? sort, int? page = 1, int? perPage = 20, bool? shared = false, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint returns a list of catalog collections.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Catalog.GetCollections(sort);
    // TODO: Handle 'response' of type CatalogCollectionDataList
}
catch (SdkException<GetCollectionsError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetCollectionsError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>sort</code> | <code>[Sort1?](Models/Enums/Sort1.cs)</code> | Sort by |
| <code>page</code> | <code>int?</code> | Page number<br>**Default**: 1 |
| <code>perPage</code> | <code>int?</code> | Number of results per page<br>**Default**: 20 |
| <code>shared</code> | <code>bool?</code> | Set to true to omit collections that you own and return only collections  that are shared with you<br>**Default**: false |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CatalogCollectionDataList](Models/CatalogCollectionDataList.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetCollectionsError](Errors/GetCollectionsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CatalogCollectionItemDataList&gt; SearchCatalog(Sort1? sort, string? query, IReadOnlyList&lt;string&gt;? collectionId, IReadOnlyList&lt;AssetType&gt;? assetType, int? page = 1, int? perPage = 20, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint searches for assets in the account's catalog. If you specify more than one search parameter, the API uses an AND condition. Array parameters can be specified multiple times; in this case, the API uses an AND or an OR condition with those values, depending on the parameter. You can also filter search terms out in the `query` parameter by prefixing the term with NOT.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Catalog.SearchCatalog(sort, query, collectionId, assetType);
    // TODO: Handle 'response' of type CatalogCollectionItemDataList
}
catch (SdkException<SearchCatalogError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type SearchCatalogError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>sort</code> | <code>[Sort1?](Models/Enums/Sort1.cs)</code> | Sort by |
| <code>query</code> | <code>string?</code> | One or more search terms separated by spaces |
| <code>collectionId</code> | <code>IReadOnlyList&lt;string&gt;?</code> | Filter by collection id |
| <code>assetType</code> | <code>IReadOnlyList&lt;[AssetType](Models/Enums/AssetType.cs)&gt;?</code> | Filter by asset type |
| <code>page</code> | <code>int?</code> | Page number<br>**Default**: 1 |
| <code>perPage</code> | <code>int?</code> | Number of results per page<br>**Default**: 20 |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CatalogCollectionItemDataList](Models/CatalogCollectionItemDataList.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[SearchCatalogError](Errors/SearchCatalogError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CatalogCollection&gt; UpdateCollection(string collectionId, UpdateCatalogCollection body, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint updates the metadata of a catalog collection.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Catalog.UpdateCollection(collectionId, body);
    // TODO: Handle 'response' of type CatalogCollection
}
catch (SdkException<RawError> ex)
{
    // TODO: Handle 'ex.Error' of type RawError
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>collectionId</code> | <code>string</code> | ID of collection that needs to be modified |
| <code>body</code> | <code>[UpdateCatalogCollection](Models/UpdateCatalogCollection.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CatalogCollection](Models/CatalogCollection.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[RawError](Core/ErrorResponse/RawError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## ComputerVision

> Source: [ComputerVision](Api/ComputerVision.cs)

<details>
<summary><code>Task&lt;KeywordDataList&gt; GetKeywords(AssetId assetId, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint returns a list of suggested keywords for a media item that you specify or upload.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ComputerVision.GetKeywords(assetId);
    // TODO: Handle 'response' of type KeywordDataList
}
catch (SdkException<GetKeywordsError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetKeywordsError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>assetId</code> | <code>[AssetId](Models/AnyOf/AssetId.cs)</code> | The asset ID or upload ID to suggest keywords for |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[KeywordDataList](Models/KeywordDataList.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetKeywordsError](Errors/GetKeywordsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ImageSearchResults&gt; GetSimilarImages(string assetId, IReadOnlyList&lt;License5&gt;? license, Language? language, View1? view, bool? safe = true, int? page = 1, int? perPage = 20, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint returns images that are visually similar to an image that you specify or upload.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ComputerVision.GetSimilarImages(assetId, license, language, view);
    // TODO: Handle 'response' of type ImageSearchResults
}
catch (SdkException<GetSimilarImagesError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetSimilarImagesError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>assetId</code> | <code>string</code> | The asset ID or upload ID to find similar images for |
| <code>license</code> | <code>IReadOnlyList&lt;[License5](Models/Enums/License5.cs)&gt;?</code> | Show only images with the specified license |
| <code>language</code> | <code>[Language?](Models/Enums/Language.cs)</code> | Language for the keywords and categories in the response |
| <code>view</code> | <code>[View1?](Models/Enums/View1.cs)</code> | Amount of detail to render in the response |
| <code>safe</code> | <code>bool?</code> | Enable or disable safe search<br>**Default**: true |
| <code>page</code> | <code>int?</code> | Page number<br>**Default**: 1 |
| <code>perPage</code> | <code>int?</code> | Number of results per page<br>**Default**: 20 |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ImageSearchResults](Models/ImageSearchResults.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetSimilarImagesError](Errors/GetSimilarImagesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;VideoSearchResults&gt; GetSimilarVideos(string assetId, IReadOnlyList&lt;License5&gt;? license, Language? language, View1? view, bool? safe = true, int? page = 1, int? perPage = 20, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint returns videos that are visually similar to an image that you specify or upload.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ComputerVision.GetSimilarVideos(assetId, license, language, view);
    // TODO: Handle 'response' of type VideoSearchResults
}
catch (SdkException<GetSimilarVideosError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetSimilarVideosError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>assetId</code> | <code>string</code> | The asset ID or upload ID to find similar videos for |
| <code>license</code> | <code>IReadOnlyList&lt;[License5](Models/Enums/License5.cs)&gt;?</code> | Show only videos with the specified license |
| <code>language</code> | <code>[Language?](Models/Enums/Language.cs)</code> | Language for the keywords and categories in the response |
| <code>view</code> | <code>[View1?](Models/Enums/View1.cs)</code> | Amount of detail to render in the response |
| <code>safe</code> | <code>bool?</code> | Enable or disable safe search<br>**Default**: true |
| <code>page</code> | <code>int?</code> | Page number<br>**Default**: 1 |
| <code>perPage</code> | <code>int?</code> | Number of results per page<br>**Default**: 20 |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[VideoSearchResults](Models/VideoSearchResults.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetSimilarVideosError](Errors/GetSimilarVideosError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ImageCreateResponse&gt; UploadEphemeralImage(ImageCreateRequest body, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Deprecated; use `POST /v2/cv/images` instead. This endpoint uploads an image for reverse image search. The image must be in JPEG or PNG format. To get the search results, pass the ID that this endpoint returns to the `GET /v2/images/{id}/similar` endpoint.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ComputerVision.UploadEphemeralImage(body);
    // TODO: Handle 'response' of type ImageCreateResponse
}
catch (SdkException<UploadEphemeralImageError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type UploadEphemeralImageError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>body</code> | <code>[ImageCreateRequest](Models/ImageCreateRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ImageCreateResponse](Models/ImageCreateResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[UploadEphemeralImageError](Errors/UploadEphemeralImageError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ComputerVisionImageCreateResponse&gt; UploadImage(ImageCreateRequest body, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint uploads an image for reverse image or video search. Images must be in JPEG or PNG format. To get the search results, pass the upload ID that this endpoint returns to the GET /v2/cv/similar/images or GET /v2/cv/similar/videos endpoints. Contact us for access to this endpoint.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ComputerVision.UploadImage(body);
    // TODO: Handle 'response' of type ComputerVisionImageCreateResponse
}
catch (SdkException<UploadImageError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type UploadImageError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>body</code> | <code>[ImageCreateRequest](Models/ImageCreateRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ComputerVisionImageCreateResponse](Models/ComputerVisionImageCreateResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[UploadImageError](Errors/UploadImageError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Contributors

> Source: [Contributors](Api/Contributors.cs)

<details>
<summary><code>Task&lt;ContributorProfile&gt; GetContributor(string contributorId, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint shows information about a single contributor, including contributor type, equipment they use, and other attributes.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Contributors.GetContributor(contributorId);
    // TODO: Handle 'response' of type ContributorProfile
}
catch (SdkException<GetContributorError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetContributorError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>contributorId</code> | <code>string</code> | Contributor ID |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ContributorProfile](Models/ContributorProfile.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetContributorError](Errors/GetContributorError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CollectionItemDataList&gt; GetContributorCollectionItems(string contributorId, string id, Sort1? sort, int? page = 1, int? perPage = 20, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint lists the IDs of items in a contributor's collection and the date that each was added.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Contributors.GetContributorCollectionItems(contributorId, id, sort);
    // TODO: Handle 'response' of type CollectionItemDataList
}
catch (SdkException<GetContributorCollectionItemsError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetContributorCollectionItemsError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>contributorId</code> | <code>string</code> | Contributor ID |
| <code>id</code> | <code>string</code> | Collection ID that belongs to the contributor |
| <code>sort</code> | <code>[Sort1?](Models/Enums/Sort1.cs)</code> | Sort order |
| <code>page</code> | <code>int?</code> | Page number<br>**Default**: 1 |
| <code>perPage</code> | <code>int?</code> | Number of results per page<br>**Default**: 20 |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CollectionItemDataList](Models/CollectionItemDataList.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetContributorCollectionItemsError](Errors/GetContributorCollectionItemsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;Collection&gt; GetContributorCollections(string contributorId, string id, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint gets more detailed information about a contributor's collection, including its cover image, timestamps for its creation, and most recent update. To get the items in collections, use GET /v2/contributors/{contributor_id}/collections/{id}/items.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Contributors.GetContributorCollections(contributorId, id);
    // TODO: Handle 'response' of type Collection
}
catch (SdkException<GetContributorCollectionsError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetContributorCollectionsError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>contributorId</code> | <code>string</code> | Contributor ID |
| <code>id</code> | <code>string</code> | Collection ID that belongs to the contributor |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[Collection](Models/Collection.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetContributorCollectionsError](Errors/GetContributorCollectionsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CollectionDataList&gt; GetContributorCollectionsList(string contributorId, Sort7? sort, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint lists collections based on contributor ID.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Contributors.GetContributorCollectionsList(contributorId, sort);
    // TODO: Handle 'response' of type CollectionDataList
}
catch (SdkException<GetContributorCollectionsListError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetContributorCollectionsListError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>contributorId</code> | <code>string</code> | Contributor ID |
| <code>sort</code> | <code>[Sort7?](Models/Enums/Sort7.cs)</code> | Sort order |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CollectionDataList](Models/CollectionDataList.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetContributorCollectionsListError](Errors/GetContributorCollectionsListError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ContributorProfileDataList&gt; GetContributorList(IReadOnlyList&lt;string&gt; id, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint lists information about one or more contributors, including contributor type, equipment they use and other attributes.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Contributors.GetContributorList(id);
    // TODO: Handle 'response' of type ContributorProfileDataList
}
catch (SdkException<GetContributorListError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetContributorListError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>id</code> | <code>IReadOnlyList&lt;string&gt;</code> | One or more contributor IDs |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ContributorProfileDataList](Models/ContributorProfileDataList.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetContributorListError](Errors/GetContributorListError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## CustomMusic

> Source: [CustomMusic](Api/CustomMusic.cs)

<details>
<summary><code>Task&lt;AudioRendersListResults&gt; CreateAudioRenders(CreateAudioRendersRequest body, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint creates rendered audio from timeline data. It returns a render ID that you can use to download the finished audio when it is ready. The render ID is valid for up to 48 hours.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.CustomMusic.CreateAudioRenders(body);
    // TODO: Handle 'response' of type AudioRendersListResults
}
catch (SdkException<CreateAudioRendersError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type CreateAudioRendersError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>body</code> | <code>[CreateAudioRendersRequest](Models/CreateAudioRendersRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[AudioRendersListResults](Models/AudioRendersListResults.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[CreateAudioRendersError](Errors/CreateAudioRendersError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;AudioRendersListResults&gt; FetchRenders(IReadOnlyList&lt;string&gt; id, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint shows the status of one or more audio renders, including download links for completed audio.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.CustomMusic.FetchRenders(id);
    // TODO: Handle 'response' of type AudioRendersListResults
}
catch (SdkException<FetchRendersError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type FetchRendersError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>id</code> | <code>IReadOnlyList&lt;string&gt;</code> | One or more render IDs |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[AudioRendersListResults](Models/AudioRendersListResults.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[FetchRendersError](Errors/FetchRendersError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;DescriptorsListResult&gt; ListCustomDescriptors(double? renderSpeedOver, string? bandId, string? bandName, IReadOnlyList&lt;string&gt;? id, string? instrumentName, string? instrumentId, double? tempo, double? tempoTo, double? tempoFrom, string? name, string? tag, int? page = 1, int? perPage = 20, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint lists the descriptors that you can use in the audio regions in an audio render.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.CustomMusic.ListCustomDescriptors(renderSpeedOver,
        bandId,
        bandName,
        id,
        instrumentName,
        instrumentId,
        tempo,
        tempoTo,
        tempoFrom,
        name,
        tag);
    // TODO: Handle 'response' of type DescriptorsListResult
}
catch (SdkException<ListCustomDescriptorsError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type ListCustomDescriptorsError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>renderSpeedOver</code> | <code>double?</code> | Show descriptors with an average render speed that is greater than or equal to the specified value |
| <code>bandId</code> | <code>string?</code> | Show descriptors that contain the specified band (case-sentsitive) |
| <code>bandName</code> | <code>string?</code> | Show descriptors with the specified band name (case-sensitive) |
| <code>id</code> | <code>IReadOnlyList&lt;string&gt;?</code> | Show descriptors with the specified IDs (case-sensitive) |
| <code>instrumentName</code> | <code>string?</code> | Show descriptors with the specified instrument name (case-sensitive) |
| <code>instrumentId</code> | <code>string?</code> | Show descriptors with the specified instrument ID (case-sensitive) |
| <code>tempo</code> | <code>double?</code> | Show descriptors whose tempo range includes the specified tempo in beats per minute |
| <code>tempoTo</code> | <code>double?</code> | Show descriptors with a tempo that is less than or equal to the specified number |
| <code>tempoFrom</code> | <code>double?</code> | Show descriptors that have a tempo range that includes the specified tempo in beats per minute |
| <code>name</code> | <code>string?</code> | Show descriptors with the specified name (case-sensitive) |
| <code>tag</code> | <code>string?</code> | Show descriptors with the specified tag, such as Cinematic or Roomy (case-sensitive) |
| <code>page</code> | <code>int?</code> | Page number<br>**Default**: 1 |
| <code>perPage</code> | <code>int?</code> | Number of results per page<br>**Default**: 20 |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[DescriptorsListResult](Models/DescriptorsListResult.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[ListCustomDescriptorsError](Errors/ListCustomDescriptorsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;InstrumentsListResult&gt; ListCustomInstruments(IReadOnlyList&lt;string&gt;? id, string? name, string? tag, int? perPage = 20, int? page = 1, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint lists the instruments that you can include in computer audio. If you specify more than one search parameter, the API uses an AND condition.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.CustomMusic.ListCustomInstruments(id, name, tag);
    // TODO: Handle 'response' of type InstrumentsListResult
}
catch (SdkException<ListCustomInstrumentsError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type ListCustomInstrumentsError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>id</code> | <code>IReadOnlyList&lt;string&gt;?</code> | Show instruments with the specified ID |
| <code>name</code> | <code>string?</code> | Show instruments with the specified name (case-sensitive) |
| <code>tag</code> | <code>string?</code> | Show instruments with the specified tag, such as Percussion or Strings (case-sensitive) |
| <code>perPage</code> | <code>int?</code> | Number of results per page<br>**Default**: 20 |
| <code>page</code> | <code>int?</code> | Page number<br>**Default**: 1 |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[InstrumentsListResult](Models/InstrumentsListResult.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[ListCustomInstrumentsError](Errors/ListCustomInstrumentsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## EditorialImages

> Source: [EditorialImages](Api/EditorialImages.cs)

<details>
<summary><code>Task&lt;EditorialContent&gt; DeprecatedGetEditorialContentDetails(string id, string country, string? searchId, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Deprecated; use `GET /v2/editorial/images/{id}` instead to show information about an editorial image, including a URL to a preview image and the sizes that it is available in.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.EditorialImages.DeprecatedGetEditorialContentDetails(id, country, searchId);
    // TODO: Handle 'response' of type EditorialContent
}
catch (SdkException<DeprecatedGetEditorialContentDetailsError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type DeprecatedGetEditorialContentDetailsError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>id</code> | <code>string</code> | Editorial ID |
| <code>country</code> | <code>string</code> | Returns only if the content is available for distribution in a certain country |
| <code>searchId</code> | <code>string?</code> | The ID of the search that is related to this request |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[EditorialContent](Models/EditorialContent.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[DeprecatedGetEditorialContentDetailsError](Errors/DeprecatedGetEditorialContentDetailsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;EditorialCategoryResults&gt; GetEditorialCategories(CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Deprecated; use `GET /v2/editorial/images/categories` instead. This endpoint lists the categories that editorial images can belong to, which are separate from the categories that other types of assets can belong to.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.EditorialImages.GetEditorialCategories();
    // TODO: Handle 'response' of type EditorialCategoryResults
}
catch (SdkException<GetEditorialCategoriesError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetEditorialCategoriesError
    }
}
```

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[EditorialCategoryResults](Models/EditorialCategoryResults.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetEditorialCategoriesError](Errors/GetEditorialCategoriesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;EditorialContent&gt; GetEditorialImage(string id, string country, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint shows information about an editorial image, including a URL to a preview image and the sizes that it is available in.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.EditorialImages.GetEditorialImage(id, country);
    // TODO: Handle 'response' of type EditorialContent
}
catch (SdkException<GetEditorialImageError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetEditorialImageError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>id</code> | <code>string</code> | Editorial ID |
| <code>country</code> | <code>string</code> | Returns only if the content is available for distribution in a certain country |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[EditorialContent](Models/EditorialContent.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetEditorialImageError](Errors/GetEditorialImageError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;DownloadHistoryDataList&gt; GetEditorialImageLicenseList(string? imageId, string? license, Sort1? sort, string? username, DateTimeOffset? startDate, DateTimeOffset? endDate, DownloadAvailability? downloadAvailability, int? page = 1, int? perPage = 20, bool? teamHistory = false, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint lists existing editorial image licenses.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.EditorialImages.GetEditorialImageLicenseList(imageId,
        license,
        sort,
        username,
        startDate,
        endDate,
        downloadAvailability);
    // TODO: Handle 'response' of type DownloadHistoryDataList
}
catch (SdkException<GetEditorialImageLicenseListError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetEditorialImageLicenseListError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>imageId</code> | <code>string?</code> | Show licenses for the specified editorial image ID |
| <code>license</code> | <code>string?</code> | Show editorial images that are available with the specified license name |
| <code>sort</code> | <code>[Sort1?](Models/Enums/Sort1.cs)</code> | Sort order |
| <code>username</code> | <code>string?</code> | Filter licenses by username of licensee |
| <code>startDate</code> | <code>DateTimeOffset?</code> | Show licenses created on or after the specified date |
| <code>endDate</code> | <code>DateTimeOffset?</code> | Show licenses created before the specified date |
| <code>downloadAvailability</code> | <code>[DownloadAvailability?](Models/Enums/DownloadAvailability.cs)</code> | Filter licenses by download availability |
| <code>page</code> | <code>int?</code> | Page number<br>**Default**: 1 |
| <code>perPage</code> | <code>int?</code> | Number of results per page<br>**Default**: 20 |
| <code>teamHistory</code> | <code>bool?</code> | Set to true to see license history for all members of your team.<br>**Default**: false |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[DownloadHistoryDataList](Models/DownloadHistoryDataList.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetEditorialImageLicenseListError](Errors/GetEditorialImageLicenseListError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;EditorialImageLivefeed&gt; GetEditorialImageLivefeed(string id, string country, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.EditorialImages.GetEditorialImageLivefeed(id, country);
    // TODO: Handle 'response' of type EditorialImageLivefeed
}
catch (SdkException<GetEditorialImageLivefeedError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetEditorialImageLivefeedError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>id</code> | <code>string</code> | Editorial livefeed ID; must be an URI encoded string |
| <code>country</code> | <code>string</code> | Returns only if the livefeed is available for distribution in a certain country |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[EditorialImageLivefeed](Models/EditorialImageLivefeed.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetEditorialImageLivefeedError](Errors/GetEditorialImageLivefeedError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;EditorialImageContentDataList&gt; GetEditorialImageLivefeedItems(string id, string country, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.EditorialImages.GetEditorialImageLivefeedItems(id, country);
    // TODO: Handle 'response' of type EditorialImageContentDataList
}
catch (SdkException<GetEditorialImageLivefeedItemsError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetEditorialImageLivefeedItemsError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>id</code> | <code>string</code> | Editorial livefeed ID; must be an URI encoded string |
| <code>country</code> | <code>string</code> | Returns only if the livefeed items are available for distribution in a certain country |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[EditorialImageContentDataList](Models/EditorialImageContentDataList.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetEditorialImageLivefeedItemsError](Errors/GetEditorialImageLivefeedItemsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;EditorialImageLivefeedList&gt; GetEditorialImageLivefeedList(string country, int? page = 1, int? perPage = 20, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.EditorialImages.GetEditorialImageLivefeedList(country);
    // TODO: Handle 'response' of type EditorialImageLivefeedList
}
catch (SdkException<GetEditorialImageLivefeedListError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetEditorialImageLivefeedListError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>country</code> | <code>string</code> | Returns only livefeeds that are available for distribution in a certain country |
| <code>page</code> | <code>int?</code> | Page number<br>**Default**: 1 |
| <code>perPage</code> | <code>int?</code> | Number of results per page<br>**Default**: 20 |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[EditorialImageLivefeedList](Models/EditorialImageLivefeedList.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetEditorialImageLivefeedListError](Errors/GetEditorialImageLivefeedListError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;EditorialLivefeed&gt; GetEditorialLivefeed(string id, string country, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Deprecated: use `GET /v2/editorial/images/livefeeds/{id}` instead to get an editorial livefeed.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.EditorialImages.GetEditorialLivefeed(id, country);
    // TODO: Handle 'response' of type EditorialLivefeed
}
catch (SdkException<GetEditorialLivefeedError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetEditorialLivefeedError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>id</code> | <code>string</code> | Editorial livefeed ID; must be an URI encoded string |
| <code>country</code> | <code>string</code> | Returns only if the livefeed is available for distribution in a certain country |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[EditorialLivefeed](Models/EditorialLivefeed.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetEditorialLivefeedError](Errors/GetEditorialLivefeedError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;EditorialContentDataList&gt; GetEditorialLivefeedItems(string id, string country, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Deprecated; use `GET /v2/editorial/images/livefeeds/{id}/items` instead to get editorial livefeed items.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.EditorialImages.GetEditorialLivefeedItems(id, country);
    // TODO: Handle 'response' of type EditorialContentDataList
}
catch (SdkException<GetEditorialLivefeedItemsError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetEditorialLivefeedItemsError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>id</code> | <code>string</code> | Editorial livefeed ID; must be an URI encoded string |
| <code>country</code> | <code>string</code> | Returns only if the livefeed items are available for distribution in a certain country |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[EditorialContentDataList](Models/EditorialContentDataList.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetEditorialLivefeedItemsError](Errors/GetEditorialLivefeedItemsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;EditorialLivefeedList&gt; GetEditorialLivefeedList(string country, int? page = 1, int? perPage = 20, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Deprecated; use `GET /v2/editorial/images/livefeeds` instead to get a list of editorial livefeeds.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.EditorialImages.GetEditorialLivefeedList(country);
    // TODO: Handle 'response' of type EditorialLivefeedList
}
catch (SdkException<GetEditorialLivefeedListError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetEditorialLivefeedListError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>country</code> | <code>string</code> | Returns only livefeeds that are available for distribution in a certain country |
| <code>page</code> | <code>int?</code> | Page number<br>**Default**: 1 |
| <code>perPage</code> | <code>int?</code> | Number of results per page<br>**Default**: 20 |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[EditorialLivefeedList](Models/EditorialLivefeedList.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetEditorialLivefeedListError](Errors/GetEditorialLivefeedListError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;EditorialUpdatedResults&gt; GetUpdatedEditorialImage(Type2 type, DateTimeOffset dateUpdatedStart, DateTimeOffset dateUpdatedEnd, string country, DateTimeOffset? dateTakenStart, DateTimeOffset? dateTakenEnd, string? cursor, Sort1? sort, IReadOnlyList&lt;string&gt;? supplierCode, int? perPage = 500, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Deprecated; use `GET /v2/editorial/images/updated` instead to get recently updated items.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.EditorialImages.GetUpdatedEditorialImage(type,
        dateUpdatedStart,
        dateUpdatedEnd,
        country,
        dateTakenStart,
        dateTakenEnd,
        cursor,
        sort,
        supplierCode);
    // TODO: Handle 'response' of type EditorialUpdatedResults
}
catch (SdkException<GetUpdatedEditorialImageError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetUpdatedEditorialImageError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>type</code> | <code>[Type2](Models/Enums/Type2.cs)</code> | Specify `addition` to return only images that were added or `edit` to return only images that were edited or deleted |
| <code>dateUpdatedStart</code> | <code>DateTimeOffset</code> | Show images images added, edited, or deleted after the specified date. Acceptable range is 1970-01-01T00:00:01 to 2038-01-19T00:00:00. |
| <code>dateUpdatedEnd</code> | <code>DateTimeOffset</code> | Show images images added, edited, or deleted before the specified date. Acceptable range is 1970-01-01T00:00:01 to 2038-01-19T00:00:00. |
| <code>country</code> | <code>string</code> | Show only editorial content that is available for distribution in a certain country |
| <code>dateTakenStart</code> | <code>DateTimeOffset?</code> | Show images that were taken on or after the specified date; use this parameter if you want recently created images from the collection instead of updated older assets |
| <code>dateTakenEnd</code> | <code>DateTimeOffset?</code> | Show images that were taken before the specified date |
| <code>cursor</code> | <code>string?</code> | The cursor of the page with which to start fetching results; this cursor is returned from previous requests |
| <code>sort</code> | <code>[Sort1?](Models/Enums/Sort1.cs)</code> | Sort by |
| <code>supplierCode</code> | <code>IReadOnlyList&lt;string&gt;?</code> | Show only editorial content from certain suppliers |
| <code>perPage</code> | <code>int?</code> | Number of results per page<br>**Default**: 500 |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[EditorialUpdatedResults](Models/EditorialUpdatedResults.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetUpdatedEditorialImageError](Errors/GetUpdatedEditorialImageError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;EditorialUpdatedResults&gt; GetUpdatedEditorialImages(Type2 type, DateTimeOffset dateUpdatedStart, DateTimeOffset dateUpdatedEnd, string country, DateTimeOffset? dateTakenStart, DateTimeOffset? dateTakenEnd, string? cursor, Sort1? sort, IReadOnlyList&lt;string&gt;? supplierCode, int? perPage = 500, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint lists editorial images that have been updated in the specified time period to update content management systems (CMS) or digital asset management (DAM) systems. In most cases, use the date_updated_start and date_updated_end parameters to specify a range updates based on when the updates happened. You can also use the date_taken_start and date_taken_end parameters to specify a range of updates based on when the image was taken.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.EditorialImages.GetUpdatedEditorialImages(type,
        dateUpdatedStart,
        dateUpdatedEnd,
        country,
        dateTakenStart,
        dateTakenEnd,
        cursor,
        sort,
        supplierCode);
    // TODO: Handle 'response' of type EditorialUpdatedResults
}
catch (SdkException<GetUpdatedEditorialImagesError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetUpdatedEditorialImagesError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>type</code> | <code>[Type2](Models/Enums/Type2.cs)</code> | Specify `addition` to return only images that were added or `edit` to return only images that were edited or deleted |
| <code>dateUpdatedStart</code> | <code>DateTimeOffset</code> | Show images images added, edited, or deleted after the specified date. Acceptable range is 1970-01-01T00:00:01 to 2038-01-19T00:00:00. |
| <code>dateUpdatedEnd</code> | <code>DateTimeOffset</code> | Show images images added, edited, or deleted before the specified date. Acceptable range is 1970-01-01T00:00:01 to 2038-01-19T00:00:00. |
| <code>country</code> | <code>string</code> | Show only editorial content that is available for distribution in a certain country |
| <code>dateTakenStart</code> | <code>DateTimeOffset?</code> | Show images that were taken on or after the specified date; use this parameter if you want recently created images from the collection instead of updated older assets |
| <code>dateTakenEnd</code> | <code>DateTimeOffset?</code> | Show images that were taken before the specified date |
| <code>cursor</code> | <code>string?</code> | The cursor of the page with which to start fetching results; this cursor is returned from previous requests |
| <code>sort</code> | <code>[Sort1?](Models/Enums/Sort1.cs)</code> | Sort by |
| <code>supplierCode</code> | <code>IReadOnlyList&lt;string&gt;?</code> | Show only editorial content from certain suppliers |
| <code>perPage</code> | <code>int?</code> | Number of results per page<br>**Default**: 500 |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[EditorialUpdatedResults](Models/EditorialUpdatedResults.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetUpdatedEditorialImagesError](Errors/GetUpdatedEditorialImagesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;LicenseEditorialContentResults&gt; LicenseEditorialImage(LicenseEditorialContentRequest body, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Deprecated; use `POST /v2/editorial/images/licenses` instead to get licenses for one or more editorial images. You must specify the country and one or more editorial images to license. The download links in the response are valid for 8 hours.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.EditorialImages.LicenseEditorialImage(body);
    // TODO: Handle 'response' of type LicenseEditorialContentResults
}
catch (SdkException<LicenseEditorialImageError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type LicenseEditorialImageError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>body</code> | <code>[LicenseEditorialContentRequest](Models/LicenseEditorialContentRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[LicenseEditorialContentResults](Models/LicenseEditorialContentResults.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[LicenseEditorialImageError](Errors/LicenseEditorialImageError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;LicenseEditorialContentResults&gt; LicenseEditorialImages(LicenseEditorialContentRequest body, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint gets licenses for one or more editorial images. You must specify the country and one or more editorial images to license. The download links in the response are valid for 8 hours.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.EditorialImages.LicenseEditorialImages(body);
    // TODO: Handle 'response' of type LicenseEditorialContentResults
}
catch (SdkException<LicenseEditorialImagesError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type LicenseEditorialImagesError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>body</code> | <code>[LicenseEditorialContentRequest](Models/LicenseEditorialContentRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[LicenseEditorialContentResults](Models/LicenseEditorialContentResults.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[LicenseEditorialImagesError](Errors/LicenseEditorialImagesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;EditorialImageCategoryResults&gt; ListEditorialImageCategories(CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint lists the categories that editorial images can belong to, which are separate from the categories that other types of assets can belong to.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.EditorialImages.ListEditorialImageCategories();
    // TODO: Handle 'response' of type EditorialImageCategoryResults
}
catch (SdkException<ListEditorialImageCategoriesError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type ListEditorialImageCategoriesError
    }
}
```

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[EditorialImageCategoryResults](Models/EditorialImageCategoryResults.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[ListEditorialImageCategoriesError](Errors/ListEditorialImageCategoriesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;EditorialSearchResults&gt; SearchEditorial(string country, string? query, Sort10? sort, string? category, IReadOnlyList&lt;string&gt;? supplierCode, DateTimeOffset? dateStart, DateTimeOffset? dateEnd, string? cursor, int? perPage = 20, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Deprecated; use `GET /v2/editorial/images/search` instead to search for editorial images.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.EditorialImages.SearchEditorial(country,
        query,
        sort,
        category,
        supplierCode,
        dateStart,
        dateEnd,
        cursor);
    // TODO: Handle 'response' of type EditorialSearchResults
}
catch (SdkException<SearchEditorialError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type SearchEditorialError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>country</code> | <code>string</code> | Show only editorial content that is available for distribution in a certain country |
| <code>query</code> | <code>string?</code> | One or more search terms separated by spaces |
| <code>sort</code> | <code>[Sort10?](Models/Enums/Sort10.cs)</code> | Sort by |
| <code>category</code> | <code>string?</code> | Show editorial content within a certain editorial category; specify by category name |
| <code>supplierCode</code> | <code>IReadOnlyList&lt;string&gt;?</code> | Show only editorial content from certain suppliers |
| <code>dateStart</code> | <code>DateTimeOffset?</code> | Show only editorial content generated on or after a specific date |
| <code>dateEnd</code> | <code>DateTimeOffset?</code> | Show only editorial content generated on or before a specific date |
| <code>cursor</code> | <code>string?</code> | The cursor of the page with which to start fetching results; this cursor is returned from previous requests |
| <code>perPage</code> | <code>int?</code> | Number of results per page<br>**Default**: 20 |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[EditorialSearchResults](Models/EditorialSearchResults.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[SearchEditorialError](Errors/SearchEditorialError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;EditorialSearchResults&gt; SearchEditorialImages(string country, string? query, Sort10? sort, string? category, IReadOnlyList&lt;string&gt;? supplierCode, DateTimeOffset? dateStart, DateTimeOffset? dateEnd, string? cursor, int? perPage = 20, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint searches for editorial images. If you specify more than one search parameter, the API uses an AND condition. For example, if you set the `category` parameter to "Alone,Performing" and also specify a `query` parameter, the results include only images that match the query and are in both the Alone and Performing categories. You can also filter search terms out in the `query` parameter by prefixing the term with NOT.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.EditorialImages.SearchEditorialImages(country,
        query,
        sort,
        category,
        supplierCode,
        dateStart,
        dateEnd,
        cursor);
    // TODO: Handle 'response' of type EditorialSearchResults
}
catch (SdkException<SearchEditorialImagesError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type SearchEditorialImagesError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>country</code> | <code>string</code> | Show only editorial content that is available for distribution in a certain country |
| <code>query</code> | <code>string?</code> | One or more search terms separated by spaces |
| <code>sort</code> | <code>[Sort10?](Models/Enums/Sort10.cs)</code> | Sort by |
| <code>category</code> | <code>string?</code> | Show editorial content with each of the specified editorial categories; specify category names in a comma-separated list |
| <code>supplierCode</code> | <code>IReadOnlyList&lt;string&gt;?</code> | Show only editorial content from certain suppliers |
| <code>dateStart</code> | <code>DateTimeOffset?</code> | Show only editorial content generated on or after a specific date |
| <code>dateEnd</code> | <code>DateTimeOffset?</code> | Show only editorial content generated on or before a specific date |
| <code>cursor</code> | <code>string?</code> | The cursor of the page with which to start fetching results; this cursor is returned from previous requests |
| <code>perPage</code> | <code>int?</code> | Number of results per page<br>**Default**: 20 |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[EditorialSearchResults](Models/EditorialSearchResults.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[SearchEditorialImagesError](Errors/SearchEditorialImagesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## EditorialVideo

> Source: [EditorialVideo](Api/EditorialVideo.cs)

<details>
<summary><code>Task&lt;EditorialVideoContent&gt; GetEditorialVideo(string id, string country, string? searchId, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint shows information about an editorial image, including a URL to a preview image and the sizes that it is available in.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.EditorialVideo.GetEditorialVideo(id, country, searchId);
    // TODO: Handle 'response' of type EditorialVideoContent
}
catch (SdkException<GetEditorialVideoError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetEditorialVideoError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>id</code> | <code>string</code> | Editorial ID |
| <code>country</code> | <code>string</code> | Returns only if the content is available for distribution in a certain country |
| <code>searchId</code> | <code>string?</code> | The ID of the search that is related to this request |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[EditorialVideoContent](Models/EditorialVideoContent.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetEditorialVideoError](Errors/GetEditorialVideoError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;DownloadHistoryDataList&gt; GetEditorialVideoLicenseList(string? videoId, string? license, Sort1? sort, string? username, DateTimeOffset? startDate, DateTimeOffset? endDate, DownloadAvailability? downloadAvailability, int? page = 1, int? perPage = 20, bool? teamHistory = false, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint lists existing editorial video licenses.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.EditorialVideo.GetEditorialVideoLicenseList(videoId,
        license,
        sort,
        username,
        startDate,
        endDate,
        downloadAvailability);
    // TODO: Handle 'response' of type DownloadHistoryDataList
}
catch (SdkException<GetEditorialVideoLicenseListError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetEditorialVideoLicenseListError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>videoId</code> | <code>string?</code> | Show licenses for the specified editorial video ID |
| <code>license</code> | <code>string?</code> | Show editorial videos that are available with the specified license name |
| <code>sort</code> | <code>[Sort1?](Models/Enums/Sort1.cs)</code> | Sort order |
| <code>username</code> | <code>string?</code> | Filter licenses by username of licensee |
| <code>startDate</code> | <code>DateTimeOffset?</code> | Show licenses created on or after the specified date |
| <code>endDate</code> | <code>DateTimeOffset?</code> | Show licenses created before the specified date |
| <code>downloadAvailability</code> | <code>[DownloadAvailability?](Models/Enums/DownloadAvailability.cs)</code> | Filter licenses by download availability |
| <code>page</code> | <code>int?</code> | Page number<br>**Default**: 1 |
| <code>perPage</code> | <code>int?</code> | Number of results per page<br>**Default**: 20 |
| <code>teamHistory</code> | <code>bool?</code> | Set to true to see license history for all members of your team.<br>**Default**: false |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[DownloadHistoryDataList](Models/DownloadHistoryDataList.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetEditorialVideoLicenseListError](Errors/GetEditorialVideoLicenseListError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;LicenseEditorialContentResults&gt; LicenseEditorialVideo(LicenseEditorialVideoContentRequest body, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint gets licenses for one or more editorial videos. You must specify the country and one or more editorial videos to license. The download links in the response are valid for 8 hours.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.EditorialVideo.LicenseEditorialVideo(body);
    // TODO: Handle 'response' of type LicenseEditorialContentResults
}
catch (SdkException<LicenseEditorialVideoError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type LicenseEditorialVideoError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>body</code> | <code>[LicenseEditorialVideoContentRequest](Models/LicenseEditorialVideoContentRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[LicenseEditorialContentResults](Models/LicenseEditorialContentResults.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[LicenseEditorialVideoError](Errors/LicenseEditorialVideoError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;EditorialVideoCategoryResults&gt; ListEditorialVideoCategories(CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint lists the categories that editorial videos can belong to, which are separate from the categories that other types of assets can belong to.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.EditorialVideo.ListEditorialVideoCategories();
    // TODO: Handle 'response' of type EditorialVideoCategoryResults
}
catch (SdkException<ListEditorialVideoCategoriesError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type ListEditorialVideoCategoriesError
    }
}
```

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[EditorialVideoCategoryResults](Models/EditorialVideoCategoryResults.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[ListEditorialVideoCategoriesError](Errors/ListEditorialVideoCategoriesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;EditorialVideoSearchResults&gt; SearchEditorialVideos(string country, string? query, Sort10? sort, string? category, IReadOnlyList&lt;string&gt;? supplierCode, DateTimeOffset? dateStart, DateTimeOffset? dateEnd, Resolution? resolution, double? fps, string? cursor, int? perPage = 20, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint searches for editorial videos. If you specify more than one search parameter, the API uses an AND condition. For example, if you set the `category` parameter to "Alone,Performing" and also specify a `query` parameter, the results include only videos that match the query and are in both the Alone and Performing categories.  You can also filter search terms out in the `query` parameter by prefixing the term with NOT.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.EditorialVideo.SearchEditorialVideos(country,
        query,
        sort,
        category,
        supplierCode,
        dateStart,
        dateEnd,
        resolution,
        fps,
        cursor);
    // TODO: Handle 'response' of type EditorialVideoSearchResults
}
catch (SdkException<SearchEditorialVideosError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type SearchEditorialVideosError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>country</code> | <code>string</code> | Show only editorial video content that is available for distribution in a certain country |
| <code>query</code> | <code>string?</code> | One or more search terms separated by spaces |
| <code>sort</code> | <code>[Sort10?](Models/Enums/Sort10.cs)</code> | Sort by |
| <code>category</code> | <code>string?</code> | Show editorial content with each of the specified editorial categories; specify category names in a comma-separated list |
| <code>supplierCode</code> | <code>IReadOnlyList&lt;string&gt;?</code> | Show only editorial video content from certain suppliers |
| <code>dateStart</code> | <code>DateTimeOffset?</code> | Show only editorial video content generated on or after a specific date |
| <code>dateEnd</code> | <code>DateTimeOffset?</code> | Show only editorial video content generated on or before a specific date |
| <code>resolution</code> | <code>[Resolution?](Models/Enums/Resolution.cs)</code> | Show only editorial video content with specific resolution |
| <code>fps</code> | <code>double?</code> | Show only editorial video content generated with specific frames per second |
| <code>cursor</code> | <code>string?</code> | The cursor of the page with which to start fetching results; this cursor is returned from previous requests |
| <code>perPage</code> | <code>int?</code> | Number of results per page<br>**Default**: 20 |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[EditorialVideoSearchResults](Models/EditorialVideoSearchResults.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[SearchEditorialVideosError](Errors/SearchEditorialVideosError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Images

> Source: [Images](Api/Images.cs)

<details>
<summary><code>Task AddImageCollectionItems(string id, CollectionItemRequest body, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint adds one or more images to a collection by image IDs.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    await client.Images.AddImageCollectionItems(id, body);
}
catch (SdkException<AddImageCollectionItemsError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type AddImageCollectionItemsError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>id</code> | <code>string</code> | Collection ID |
| <code>body</code> | <code>[CollectionItemRequest](Models/CollectionItemRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: No content

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[AddImageCollectionItemsError](Errors/AddImageCollectionItemsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;BulkImageSearchResults&gt; BulkSearchImages(DateTimeOffset? addedDate, DateTimeOffset? addedDateStart, double? aspectRatioMin, double? aspectRatioMax, double? aspectRatio, DateTimeOffset? addedDateEnd, string? category, string? color, IReadOnlyList&lt;string&gt;? contributor, ContributorCountryModel? contributorCountry, string? fields, int? height, int? heightFrom, int? heightTo, IReadOnlyList&lt;ImageType1&gt;? imageType, Language? language, IReadOnlyList&lt;License&gt;? license, IReadOnlyList&lt;string&gt;? model, Orientation1? orientation, bool? peopleModelReleased, PeopleAge1? peopleAge, IReadOnlyList&lt;PeopleEthnicity1&gt;? peopleEthnicity, PeopleGender1? peopleGender, int? peopleNumber, Region1Model? region, Sort4? sort, View1? view, int? width, int? widthFrom, int? widthTo, IReadOnlyList&lt;SearchImage&gt; body, bool? keywordSafeSearch = true, int? page = 1, int? perPage = 20, bool? safe = true, bool? spellcheckQuery = true, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint runs up to 5 image searches in a single request and returns up to 20 results per search. You can provide global search parameters in the query parameters and override them for each search in the body parameter. The query and body parameters are the same as in the `GET /v2/images/search` endpoint.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Images.BulkSearchImages(addedDate,
        addedDateStart,
        aspectRatioMin,
        aspectRatioMax,
        aspectRatio,
        addedDateEnd,
        category,
        color,
        contributor,
        contributorCountry,
        fields,
        height,
        heightFrom,
        heightTo,
        imageType,
        language,
        license,
        model,
        orientation,
        peopleModelReleased,
        peopleAge,
        peopleEthnicity,
        peopleGender,
        peopleNumber,
        region,
        sort,
        view,
        width,
        widthFrom,
        widthTo,
        body);
    // TODO: Handle 'response' of type BulkImageSearchResults
}
catch (SdkException<BulkSearchImagesError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type BulkSearchImagesError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>addedDate</code> | <code>DateTimeOffset?</code> | Show images added on the specified date |
| <code>addedDateStart</code> | <code>DateTimeOffset?</code> | Show images added on or after the specified date |
| <code>aspectRatioMin</code> | <code>double?</code> | Show images with the specified aspect ratio or higher, using a positive decimal of the width divided by the height, such as 1.7778 for a 16:9 image |
| <code>aspectRatioMax</code> | <code>double?</code> | Show images with the specified aspect ratio or lower, using a positive decimal of the width divided by the height, such as 1.7778 for a 16:9 image |
| <code>aspectRatio</code> | <code>double?</code> | Show images with the specified aspect ratio, using a positive decimal of the width divided by the height, such as 1.7778 for a 16:9 image |
| <code>addedDateEnd</code> | <code>DateTimeOffset?</code> | Show images added before the specified date |
| <code>category</code> | <code>string?</code> | Show images with the specified Shutterstock-defined category; specify a category name or ID |
| <code>color</code> | <code>string?</code> | Specify either a hexadecimal color in the format '4F21EA' or 'grayscale'; the API returns images that use similar colors |
| <code>contributor</code> | <code>IReadOnlyList&lt;string&gt;?</code> | Show images with the specified contributor names or IDs, allows multiple |
| <code>contributorCountry</code> | <code>[ContributorCountryModel?](Models/AnyOf/ContributorCountryModel.cs)</code> | Show images from contributors in one or more specified countries, or start with NOT to exclude a country from the search |
| <code>fields</code> | <code>string?</code> | Fields to display in the response; see the documentation for the fields parameter in the overview section |
| <code>height</code> | <code>int?</code> | (Deprecated; use height_from and height_to instead) Show images with the specified height |
| <code>heightFrom</code> | <code>int?</code> | Show images with the specified height or larger, in pixels |
| <code>heightTo</code> | <code>int?</code> | Show images with the specified height or smaller, in pixels |
| <code>imageType</code> | <code>IReadOnlyList&lt;[ImageType1](Models/Enums/ImageType1.cs)&gt;?</code> | Show images of the specified type |
| <code>language</code> | <code>[Language?](Models/Enums/Language.cs)</code> | Set query and result language (uses Accept-Language header if not set) |
| <code>license</code> | <code>IReadOnlyList&lt;[License](Models/Enums/License.cs)&gt;?</code> | Show only images with the specified license |
| <code>model</code> | <code>IReadOnlyList&lt;string&gt;?</code> | Show image results with the specified model IDs |
| <code>orientation</code> | <code>[Orientation1?](Models/Enums/Orientation1.cs)</code> | Show image results with horizontal or vertical orientation |
| <code>peopleModelReleased</code> | <code>bool?</code> | Show images of people with a signed model release |
| <code>peopleAge</code> | <code>[PeopleAge1?](Models/Enums/PeopleAge1.cs)</code> | Show images that feature people of the specified age category |
| <code>peopleEthnicity</code> | <code>IReadOnlyList&lt;[PeopleEthnicity1](Models/Enums/PeopleEthnicity1.cs)&gt;?</code> | Show images with people of the specified ethnicities, or start with NOT to show images without those ethnicities |
| <code>peopleGender</code> | <code>[PeopleGender1?](Models/Enums/PeopleGender1.cs)</code> | Show images with people of the specified gender |
| <code>peopleNumber</code> | <code>int?</code> | Show images with the specified number of people |
| <code>region</code> | <code>[Region1Model?](Models/AnyOf/Region1Model.cs)</code> | Raise or lower search result rankings based on the result's relevance to a specified region; you can provide a country code or an IP address from which the API infers a country |
| <code>sort</code> | <code>[Sort4?](Models/Enums/Sort4.cs)</code> | Sort by |
| <code>view</code> | <code>[View1?](Models/Enums/View1.cs)</code> | Amount of detail to render in the response |
| <code>width</code> | <code>int?</code> | (Deprecated; use width_from and width_to instead) Show images with the specified width |
| <code>widthFrom</code> | <code>int?</code> | Show images with the specified width or larger, in pixels |
| <code>widthTo</code> | <code>int?</code> | Show images with the specified width or smaller, in pixels |
| <code>body</code> | <code>IReadOnlyList&lt;[SearchImage](Models/SearchImage.cs)&gt;</code> | - |
| <code>keywordSafeSearch</code> | <code>bool?</code> | Hide results with potentially unsafe keywords<br>**Default**: true |
| <code>page</code> | <code>int?</code> | Page number<br>**Default**: 1 |
| <code>perPage</code> | <code>int?</code> | Number of results per page<br>**Default**: 20 |
| <code>safe</code> | <code>bool?</code> | Enable or disable safe search<br>**Default**: true |
| <code>spellcheckQuery</code> | <code>bool?</code> | Spellcheck the search query and return results on suggested spellings<br>**Default**: true |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[BulkImageSearchResults](Models/BulkImageSearchResults.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[BulkSearchImagesError](Errors/BulkSearchImagesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CollectionCreateResponse&gt; CreateImageCollection(CollectionCreateRequest body, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint creates one or more image collections (lightboxes). To add images to the collections, use `POST /v2/images/collections/{id}/items`.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Images.CreateImageCollection(body);
    // TODO: Handle 'response' of type CollectionCreateResponse
}
catch (SdkException<CreateImageCollectionError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type CreateImageCollectionError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>body</code> | <code>[CollectionCreateRequest](Models/CollectionCreateRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CollectionCreateResponse](Models/CollectionCreateResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[CreateImageCollectionError](Errors/CreateImageCollectionError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task DeleteImageCollection(string id, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint deletes an image collection.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    await client.Images.DeleteImageCollection(id);
}
catch (SdkException<DeleteImageCollectionError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type DeleteImageCollectionError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>id</code> | <code>string</code> | Collection ID |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: No content

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[DeleteImageCollectionError](Errors/DeleteImageCollectionError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task DeleteImageCollectionItems(string id, IReadOnlyList&lt;string&gt;? itemId, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint removes one or more images from a collection.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    await client.Images.DeleteImageCollectionItems(id, itemId);
}
catch (SdkException<DeleteImageCollectionItemsError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type DeleteImageCollectionItemsError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>id</code> | <code>string</code> | Collection ID |
| <code>itemId</code> | <code>IReadOnlyList&lt;string&gt;?</code> | One or more image IDs to remove from the collection |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: No content

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[DeleteImageCollectionItemsError](Errors/DeleteImageCollectionItemsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;Url&gt; DownloadImage(string id, RedownloadImage body, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint redownloads images that you have already received a license for. The download links in the response are valid for 8 hours.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Images.DownloadImage(id, body);
    // TODO: Handle 'response' of type Url
}
catch (SdkException<DownloadImageError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type DownloadImageError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>id</code> | <code>string</code> | License ID |
| <code>body</code> | <code>[RedownloadImage](Models/RedownloadImage.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[Url](Models/Url.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[DownloadImageError](Errors/DownloadImageError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;FeaturedCollection&gt; GetFeaturedImageCollection(string id, Embed3? embed, AssetHint? assetHint, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint gets more detailed information about a featured collection, including its cover image and timestamps for its creation and most recent update. To get the images, use `GET /v2/images/collections/featured/{id}/items`.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Images.GetFeaturedImageCollection(id, embed, assetHint);
    // TODO: Handle 'response' of type FeaturedCollection
}
catch (SdkException<GetFeaturedImageCollectionError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetFeaturedImageCollectionError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>id</code> | <code>string</code> | Collection ID |
| <code>embed</code> | <code>[Embed3?](Models/Enums/Embed3.cs)</code> | Which sharing information to include in the response, such as a URL to the collection |
| <code>assetHint</code> | <code>[AssetHint?](Models/Enums/AssetHint.cs)</code> | Cover image size |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[FeaturedCollection](Models/FeaturedCollection.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetFeaturedImageCollectionError](Errors/GetFeaturedImageCollectionError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CollectionItemDataList&gt; GetFeaturedImageCollectionItems(string id, int? page = 1, int? perPage = 100, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint lists the IDs of images in a featured collection and the date that each was added.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Images.GetFeaturedImageCollectionItems(id);
    // TODO: Handle 'response' of type CollectionItemDataList
}
catch (SdkException<GetFeaturedImageCollectionItemsError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetFeaturedImageCollectionItemsError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>id</code> | <code>string</code> | Collection ID |
| <code>page</code> | <code>int?</code> | Page number<br>**Default**: 1 |
| <code>perPage</code> | <code>int?</code> | Number of results per page<br>**Default**: 100 |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CollectionItemDataList](Models/CollectionItemDataList.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetFeaturedImageCollectionItemsError](Errors/GetFeaturedImageCollectionItemsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;FeaturedCollectionDataList&gt; GetFeaturedImageCollectionList(Embed3? embed, IReadOnlyList&lt;Type4&gt;? type, AssetHint? assetHint, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint lists featured collections of specific types and a name and cover image for each collection.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Images.GetFeaturedImageCollectionList(embed, type, assetHint);
    // TODO: Handle 'response' of type FeaturedCollectionDataList
}
catch (SdkException<GetFeaturedImageCollectionListError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetFeaturedImageCollectionListError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>embed</code> | <code>[Embed3?](Models/Enums/Embed3.cs)</code> | Which sharing information to include in the response, such as a URL to the collection |
| <code>type</code> | <code>IReadOnlyList&lt;[Type4](Models/Enums/Type4.cs)&gt;?</code> | The types of collections to return |
| <code>assetHint</code> | <code>[AssetHint?](Models/Enums/AssetHint.cs)</code> | Cover image size |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[FeaturedCollectionDataList](Models/FeaturedCollectionDataList.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetFeaturedImageCollectionListError](Errors/GetFeaturedImageCollectionListError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;Image&gt; GetImage(string id, Language? language, View1? view, string? searchId, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint shows information about an image, including a URL to a preview image and the sizes that it is available in.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Images.GetImage(id, language, view, searchId);
    // TODO: Handle 'response' of type Image
}
catch (SdkException<GetImageError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetImageError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>id</code> | <code>string</code> | Image ID |
| <code>language</code> | <code>[Language?](Models/Enums/Language.cs)</code> | Language for the keywords and categories in the response |
| <code>view</code> | <code>[View1?](Models/Enums/View1.cs)</code> | Amount of detail to render in the response |
| <code>searchId</code> | <code>string?</code> | The ID of the search that is related to this request |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[Image](Models/Image.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetImageError](Errors/GetImageError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;Collection&gt; GetImageCollection(string id, IReadOnlyList&lt;Embed&gt;? embed, string? shareCode, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint gets more detailed information about a collection, including its cover image and timestamps for its creation and most recent update. To get the images in collections, use `GET /v2/images/collections/{id}/items`.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Images.GetImageCollection(id, embed, shareCode);
    // TODO: Handle 'response' of type Collection
}
catch (SdkException<GetImageCollectionError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetImageCollectionError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>id</code> | <code>string</code> | Collection ID |
| <code>embed</code> | <code>IReadOnlyList&lt;[Embed](Models/Enums/Embed.cs)&gt;?</code> | Which sharing information to include in the response, such as a URL to the collection |
| <code>shareCode</code> | <code>string?</code> | Code to retrieve a shared collection |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[Collection](Models/Collection.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetImageCollectionError](Errors/GetImageCollectionError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CollectionItemDataList&gt; GetImageCollectionItems(string id, string? shareCode, Sort1? sort, int? page = 1, int? perPage = 100, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint lists the IDs of images in a collection and the date that each was added.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Images.GetImageCollectionItems(id, shareCode, sort);
    // TODO: Handle 'response' of type CollectionItemDataList
}
catch (SdkException<GetImageCollectionItemsError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetImageCollectionItemsError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>id</code> | <code>string</code> | Collection ID |
| <code>shareCode</code> | <code>string?</code> | Code to retrieve the contents of a shared collection |
| <code>sort</code> | <code>[Sort1?](Models/Enums/Sort1.cs)</code> | Sort order |
| <code>page</code> | <code>int?</code> | Page number<br>**Default**: 1 |
| <code>perPage</code> | <code>int?</code> | Number of results per page<br>**Default**: 100 |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CollectionItemDataList](Models/CollectionItemDataList.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetImageCollectionItemsError](Errors/GetImageCollectionItemsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CollectionDataList&gt; GetImageCollectionList(IReadOnlyList&lt;Embed&gt;? embed, int? page = 1, int? perPage = 100, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint lists your collections of images and their basic attributes.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Images.GetImageCollectionList(embed);
    // TODO: Handle 'response' of type CollectionDataList
}
catch (SdkException<GetImageCollectionListError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetImageCollectionListError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>embed</code> | <code>IReadOnlyList&lt;[Embed](Models/Enums/Embed.cs)&gt;?</code> | Which sharing information to include in the response, such as a URL to the collection |
| <code>page</code> | <code>int?</code> | Page number<br>**Default**: 1 |
| <code>perPage</code> | <code>int?</code> | Number of results per page<br>**Default**: 100 |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CollectionDataList](Models/CollectionDataList.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetImageCollectionListError](Errors/GetImageCollectionListError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;SearchEntitiesResponse&gt; GetImageKeywordSuggestions(SearchEntitiesRequest body, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint returns up to 10 important keywords from a block of plain text.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Images.GetImageKeywordSuggestions(body);
    // TODO: Handle 'response' of type SearchEntitiesResponse
}
catch (SdkException<GetImageKeywordSuggestionsError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetImageKeywordSuggestionsError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>body</code> | <code>[SearchEntitiesRequest](Models/SearchEntitiesRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[SearchEntitiesResponse](Models/SearchEntitiesResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetImageKeywordSuggestionsError](Errors/GetImageKeywordSuggestionsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;DownloadHistoryDataList&gt; GetImageLicenseList(string? imageId, string? license, Sort1? sort, string? username, DateTimeOffset? startDate, DateTimeOffset? endDate, DownloadAvailability? downloadAvailability, int? page = 1, int? perPage = 20, bool? teamHistory = false, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint lists existing licenses.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Images.GetImageLicenseList(imageId,
        license,
        sort,
        username,
        startDate,
        endDate,
        downloadAvailability);
    // TODO: Handle 'response' of type DownloadHistoryDataList
}
catch (SdkException<GetImageLicenseListError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetImageLicenseListError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>imageId</code> | <code>string?</code> | Show licenses for the specified image ID |
| <code>license</code> | <code>string?</code> | Show images that are available with the specified license, such as `standard` or `enhanced`; prepending a `-` sign excludes results from that license |
| <code>sort</code> | <code>[Sort1?](Models/Enums/Sort1.cs)</code> | Sort order |
| <code>username</code> | <code>string?</code> | Filter licenses by username of licensee |
| <code>startDate</code> | <code>DateTimeOffset?</code> | Show licenses created on or after the specified date |
| <code>endDate</code> | <code>DateTimeOffset?</code> | Show licenses created before the specified date |
| <code>downloadAvailability</code> | <code>[DownloadAvailability?](Models/Enums/DownloadAvailability.cs)</code> | Filter licenses by download availability |
| <code>page</code> | <code>int?</code> | Page number<br>**Default**: 1 |
| <code>perPage</code> | <code>int?</code> | Number of results per page<br>**Default**: 20 |
| <code>teamHistory</code> | <code>bool?</code> | Set to true to see license history for all members of your team.<br>**Default**: false |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[DownloadHistoryDataList](Models/DownloadHistoryDataList.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetImageLicenseListError](Errors/GetImageLicenseListError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ImageDataList&gt; GetImageList(IReadOnlyList&lt;string&gt; id, View1? view, string? searchId, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint lists information about one or more images, including the available sizes.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Images.GetImageList(id, view, searchId);
    // TODO: Handle 'response' of type ImageDataList
}
catch (SdkException<GetImageListError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetImageListError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>id</code> | <code>IReadOnlyList&lt;string&gt;</code> | One or more image IDs |
| <code>view</code> | <code>[View1?](Models/Enums/View1.cs)</code> | Amount of detail to render in the response |
| <code>searchId</code> | <code>string?</code> | The ID of the search that is related to this request |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ImageDataList](Models/ImageDataList.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetImageListError](Errors/GetImageListError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;RecommendationDataList&gt; GetImageRecommendations(IReadOnlyList&lt;string&gt; id, int? maxItems = 20, bool? safe = true, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint returns images that customers put in the same collection as the specified image IDs.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Images.GetImageRecommendations(id);
    // TODO: Handle 'response' of type RecommendationDataList
}
catch (SdkException<GetImageRecommendationsError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetImageRecommendationsError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>id</code> | <code>IReadOnlyList&lt;string&gt;</code> | Image IDs |
| <code>maxItems</code> | <code>int?</code> | Maximum number of results returned in the response<br>**Default**: 20 |
| <code>safe</code> | <code>bool?</code> | Restrict results to safe images<br>**Default**: true |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[RecommendationDataList](Models/RecommendationDataList.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetImageRecommendationsError](Errors/GetImageRecommendationsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;Suggestions&gt; GetImageSuggestions(string query, int? limit = 10, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint provides autocomplete suggestions for partial search terms.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Images.GetImageSuggestions(query);
    // TODO: Handle 'response' of type Suggestions
}
catch (SdkException<GetImageSuggestionsError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetImageSuggestionsError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>query</code> | <code>string</code> | Search term for which you want keyword suggestions |
| <code>limit</code> | <code>int?</code> | Limit the number of suggestions<br>**Default**: 10 |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[Suggestions](Models/Suggestions.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetImageSuggestionsError](Errors/GetImageSuggestionsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;UpdatedMediaDataList&gt; GetUpdatedImages(IReadOnlyList&lt;Type5&gt;? type, DateTimeOffset? startDate, DateTimeOffset? endDate, Sort1? sort, string? interval = "1 HOUR", int? page = 1, int? perPage = 100, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint lists images that have been updated in the specified time period to update content management systems (CMS) or digital asset management (DAM) systems. In most cases, use the `interval` parameter to show images that were updated recently, but you can also use the `start_date` and `end_date` parameters to specify a range of no more than three days. Do not use the `interval` parameter with either `start_date` or `end_date`.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Images.GetUpdatedImages(type, startDate, endDate, sort);
    // TODO: Handle 'response' of type UpdatedMediaDataList
}
catch (SdkException<RawError> ex)
{
    // TODO: Handle 'ex.Error' of type RawError
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>type</code> | <code>IReadOnlyList&lt;[Type5](Models/Enums/Type5.cs)&gt;?</code> | Show images that were added, deleted, or edited; by default, the endpoint returns images that were updated in any of these ways |
| <code>startDate</code> | <code>DateTimeOffset?</code> | Show images updated on or after the specified date |
| <code>endDate</code> | <code>DateTimeOffset?</code> | Show images updated before the specified date |
| <code>sort</code> | <code>[Sort1?](Models/Enums/Sort1.cs)</code> | Sort order |
| <code>interval</code> | <code>string?</code> | Show images updated in the specified time period, where the time period is an interval (like SQL INTERVAL) such as 1 DAY, 6 HOUR, or 30 MINUTE; the default is 1 HOUR, which shows images that were updated in the hour preceding the request<br>**Default**: "1 HOUR" |
| <code>page</code> | <code>int?</code> | Page number<br>**Default**: 1 |
| <code>perPage</code> | <code>int?</code> | Number of results per page<br>**Default**: 100 |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[UpdatedMediaDataList](Models/UpdatedMediaDataList.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[RawError](Core/ErrorResponse/RawError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;LicenseImageResultDataList&gt; LicenseImages(string? subscriptionId, Format4? format, Size8? size, string? searchId, LicenseImageRequest body, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint gets licenses for one or more images. You must specify the image IDs in the body parameter and other details like the format, size, and subscription ID either in the query parameter or with each image ID in the body parameter. Values in the body parameter override values in the query parameters. The download links in the response are valid for 8 hours.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Images.LicenseImages(subscriptionId, format, size, searchId, body);
    // TODO: Handle 'response' of type LicenseImageResultDataList
}
catch (SdkException<LicenseImagesError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type LicenseImagesError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>subscriptionId</code> | <code>string?</code> | Subscription ID to use to license the image |
| <code>format</code> | <code>[Format4?](Models/Enums/Format4.cs)</code> | (Deprecated) Image format |
| <code>size</code> | <code>[Size8?](Models/Enums/Size8.cs)</code> | Image size |
| <code>searchId</code> | <code>string?</code> | Search ID that was provided in the results of an image search |
| <code>body</code> | <code>[LicenseImageRequest](Models/LicenseImageRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[LicenseImageResultDataList](Models/LicenseImageResultDataList.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[LicenseImagesError](Errors/LicenseImagesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CategoryDataList&gt; ListImageCategories(Language? language, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint lists the categories (Shutterstock-assigned genres) that images can belong to.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Images.ListImageCategories(language);
    // TODO: Handle 'response' of type CategoryDataList
}
catch (SdkException<ListImageCategoriesError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type ListImageCategoriesError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>language</code> | <code>[Language?](Models/Enums/Language.cs)</code> | Language for the keywords and categories in the response |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CategoryDataList](Models/CategoryDataList.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[ListImageCategoriesError](Errors/ListImageCategoriesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ImageSearchResults&gt; ListSimilarImages(string id, Language? language, View1? view, int? page = 1, int? perPage = 20, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint returns images that are visually similar to an image that you specify.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Images.ListSimilarImages(id, language, view);
    // TODO: Handle 'response' of type ImageSearchResults
}
catch (SdkException<ListSimilarImagesError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type ListSimilarImagesError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>id</code> | <code>string</code> | Image ID |
| <code>language</code> | <code>[Language?](Models/Enums/Language.cs)</code> | Language for the keywords and categories in the response |
| <code>view</code> | <code>[View1?](Models/Enums/View1.cs)</code> | Amount of detail to render in the response |
| <code>page</code> | <code>int?</code> | Page number<br>**Default**: 1 |
| <code>perPage</code> | <code>int?</code> | Number of results per page<br>**Default**: 20 |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ImageSearchResults](Models/ImageSearchResults.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[ListSimilarImagesError](Errors/ListSimilarImagesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task RenameImageCollection(string id, CollectionUpdateRequest body, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint sets a new name for an image collection.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    await client.Images.RenameImageCollection(id, body);
}
catch (SdkException<RenameImageCollectionError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type RenameImageCollectionError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>id</code> | <code>string</code> | Collection ID |
| <code>body</code> | <code>[CollectionUpdateRequest](Models/CollectionUpdateRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: No content

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[RenameImageCollectionError](Errors/RenameImageCollectionError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ImageSearchResults&gt; SearchImages(DateTimeOffset? addedDate, DateTimeOffset? addedDateStart, double? aspectRatioMin, double? aspectRatioMax, double? aspectRatio, bool? aiSearch, AiIndustry? aiIndustry, AiObjective? aiObjective, DateTimeOffset? addedDateEnd, string? category, string? color, IReadOnlyList&lt;string&gt;? contributor, ContributorCountryModel? contributorCountry, string? fields, int? height, int? heightFrom, int? heightTo, IReadOnlyList&lt;ImageType1&gt;? imageType, Language? language, IReadOnlyList&lt;License&gt;? license, IReadOnlyList&lt;string&gt;? model, Orientation1? orientation, bool? peopleModelReleased, PeopleAge1? peopleAge, IReadOnlyList&lt;PeopleEthnicity1&gt;? peopleEthnicity, PeopleGender1? peopleGender, int? peopleNumber, string? query, Region1Model? region, Sort4? sort, View1? view, int? width, int? widthFrom, int? widthTo, int? aiLabelsLimit = 20, bool? keywordSafeSearch = true, int? page = 1, int? perPage = 20, bool? safe = true, bool? spellcheckQuery = true, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint searches for images. If you specify more than one search parameter, the API uses an AND condition. Array parameters can be specified multiple times; in this case, the API uses an AND or an OR condition with those values, depending on the parameter. You can also filter search terms out in the `query` parameter by prefixing the term with NOT. Free API accounts show results only from a limited library of media, not the full Shutterstock media library. Also, the number of search fields they can use in a request is limited.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Images.SearchImages(addedDate,
        addedDateStart,
        aspectRatioMin,
        aspectRatioMax,
        aspectRatio,
        aiSearch,
        aiIndustry,
        aiObjective,
        addedDateEnd,
        category,
        color,
        contributor,
        contributorCountry,
        fields,
        height,
        heightFrom,
        heightTo,
        imageType,
        language,
        license,
        model,
        orientation,
        peopleModelReleased,
        peopleAge,
        peopleEthnicity,
        peopleGender,
        peopleNumber,
        query,
        region,
        sort,
        view,
        width,
        widthFrom,
        widthTo);
    // TODO: Handle 'response' of type ImageSearchResults
}
catch (SdkException<SearchImagesError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type SearchImagesError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>addedDate</code> | <code>DateTimeOffset?</code> | Show images added on the specified date |
| <code>addedDateStart</code> | <code>DateTimeOffset?</code> | Show images added on or after the specified date |
| <code>aspectRatioMin</code> | <code>double?</code> | Show images with the specified aspect ratio or higher, using a positive decimal of the width divided by the height, such as 1.7778 for a 16:9 image |
| <code>aspectRatioMax</code> | <code>double?</code> | Show images with the specified aspect ratio or lower, using a positive decimal of the width divided by the height, such as 1.7778 for a 16:9 image |
| <code>aspectRatio</code> | <code>double?</code> | Show images with the specified aspect ratio, using a positive decimal of the width divided by the height, such as 1.7778 for a 16:9 image |
| <code>aiSearch</code> | <code>bool?</code> | Set to true and specify the `ai_objective` and `ai_industry` parameters to use AI-powered search; the API returns information about how well images meet the objective for the industry |
| <code>aiIndustry</code> | <code>[AiIndustry?](Models/Enums/AiIndustry.cs)</code> | For AI-powered search, specify the industry to target; requires that the `ai_search` parameter is set to true |
| <code>aiObjective</code> | <code>[AiObjective?](Models/Enums/AiObjective.cs)</code> | For AI-powered search, specify the goal of the media; requires that the `ai_search` parameter is set to true |
| <code>addedDateEnd</code> | <code>DateTimeOffset?</code> | Show images added before the specified date |
| <code>category</code> | <code>string?</code> | Show images with the specified Shutterstock-defined category; specify a category name or ID |
| <code>color</code> | <code>string?</code> | Specify either a hexadecimal color in the format '4F21EA' or 'grayscale'; the API returns images that use similar colors |
| <code>contributor</code> | <code>IReadOnlyList&lt;string&gt;?</code> | Show images with the specified contributor names or IDs, allows multiple |
| <code>contributorCountry</code> | <code>[ContributorCountryModel?](Models/AnyOf/ContributorCountryModel.cs)</code> | Show images from contributors in one or more specified countries, or start with NOT to exclude a country from the search |
| <code>fields</code> | <code>string?</code> | Fields to display in the response; see the documentation for the fields parameter in the overview section |
| <code>height</code> | <code>int?</code> | (Deprecated; use height_from and height_to instead) Show images with the specified height |
| <code>heightFrom</code> | <code>int?</code> | Show images with the specified height or larger, in pixels |
| <code>heightTo</code> | <code>int?</code> | Show images with the specified height or smaller, in pixels |
| <code>imageType</code> | <code>IReadOnlyList&lt;[ImageType1](Models/Enums/ImageType1.cs)&gt;?</code> | Show images of the specified type |
| <code>language</code> | <code>[Language?](Models/Enums/Language.cs)</code> | Set query and result language (uses Accept-Language header if not set) |
| <code>license</code> | <code>IReadOnlyList&lt;[License](Models/Enums/License.cs)&gt;?</code> | Show only images with the specified license |
| <code>model</code> | <code>IReadOnlyList&lt;string&gt;?</code> | Show image results with the specified model IDs |
| <code>orientation</code> | <code>[Orientation1?](Models/Enums/Orientation1.cs)</code> | Show image results with horizontal or vertical orientation |
| <code>peopleModelReleased</code> | <code>bool?</code> | Show images of people with a signed model release |
| <code>peopleAge</code> | <code>[PeopleAge1?](Models/Enums/PeopleAge1.cs)</code> | Show images that feature people of the specified age category |
| <code>peopleEthnicity</code> | <code>IReadOnlyList&lt;[PeopleEthnicity1](Models/Enums/PeopleEthnicity1.cs)&gt;?</code> | Show images with people of the specified ethnicities, or start with NOT to show images without those ethnicities |
| <code>peopleGender</code> | <code>[PeopleGender1?](Models/Enums/PeopleGender1.cs)</code> | Show images with people of the specified gender |
| <code>peopleNumber</code> | <code>int?</code> | Show images with the specified number of people |
| <code>query</code> | <code>string?</code> | One or more search terms separated by spaces; you can use NOT to filter out images that match a term |
| <code>region</code> | <code>[Region1Model?](Models/AnyOf/Region1Model.cs)</code> | Raise or lower search result rankings based on the result's relevance to a specified region; you can provide a country code or an IP address from which the API infers a country |
| <code>sort</code> | <code>[Sort4?](Models/Enums/Sort4.cs)</code> | Sort by |
| <code>view</code> | <code>[View1?](Models/Enums/View1.cs)</code> | Amount of detail to render in the response |
| <code>width</code> | <code>int?</code> | (Deprecated; use width_from and width_to instead) Show images with the specified width |
| <code>widthFrom</code> | <code>int?</code> | Show images with the specified width or larger, in pixels |
| <code>widthTo</code> | <code>int?</code> | Show images with the specified width or smaller, in pixels |
| <code>aiLabelsLimit</code> | <code>int?</code> | For AI-powered search, specify the maximum number of labels to return<br>**Default**: 20 |
| <code>keywordSafeSearch</code> | <code>bool?</code> | Hide results with potentially unsafe keywords<br>**Default**: true |
| <code>page</code> | <code>int?</code> | Page number<br>**Default**: 1 |
| <code>perPage</code> | <code>int?</code> | Number of results per page<br>**Default**: 20 |
| <code>safe</code> | <code>bool?</code> | Enable or disable safe search<br>**Default**: true |
| <code>spellcheckQuery</code> | <code>bool?</code> | Spellcheck the search query and return results on suggested spellings<br>**Default**: true |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ImageSearchResults](Models/ImageSearchResults.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[SearchImagesError](Errors/SearchImagesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Oauth

> Source: [Oauth](Api/Oauth.cs)

<details>
<summary><code>Task Authorize(string clientId, string redirectUri, ResponseType responseType, string state, Realm2? realm, string? scope = "user.view", CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint returns a redirect URI (in the 'Location' header) that the customer uses to authorize your application and, together with POST /v2/oauth/access_token, generate an access token that represents that authorization.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    await client.Oauth.Authorize(clientId, redirectUri, responseType, state, realm);
}
catch (SdkException<AuthorizeError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type AuthorizeError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>clientId</code> | <code>string</code> | Client ID (Consumer Key) of your application |
| <code>redirectUri</code> | <code>string</code> | The callback URI to send the request to after authorization; must use a host name that is registered with your application |
| <code>responseType</code> | <code>[ResponseType](Models/Enums/ResponseType.cs)</code> | Type of temporary authorization code that will be used to generate an access code; the only valid value is 'code' |
| <code>state</code> | <code>string</code> | Unique value used by the calling app to verify the request |
| <code>realm</code> | <code>[Realm2?](Models/Enums/Realm2.cs)</code> | User type to be authorized (usually 'customer') |
| <code>scope</code> | <code>string?</code> | Space-separated list of scopes to be authorized<br>**Default**: "user.view" |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: No content

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[AuthorizeError](Errors/AuthorizeError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;OauthAccessTokenResponse&gt; CreateAccessToken(string clientId, GrantType grantType, string? clientSecret, string? code, Expires? expires, Realm1? realm, string? refreshToken, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint returns an access token for the specified user and with the specified scopes. The token does not expire until the user changes their password. The body parameters must be encoded as form data.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Oauth.CreateAccessToken(clientId,
        grantType,
        clientSecret,
        code,
        expires,
        realm,
        refreshToken);
    // TODO: Handle 'response' of type OauthAccessTokenResponse
}
catch (SdkException<CreateAccessTokenError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type CreateAccessTokenError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>clientId</code> | <code>string</code> | - |
| <code>grantType</code> | <code>[GrantType](Models/Enums/GrantType.cs)</code> | - |
| <code>clientSecret</code> | <code>string?</code> | - |
| <code>code</code> | <code>string?</code> | - |
| <code>expires</code> | <code>[Expires?](Models/Enums/Expires.cs)</code> | - |
| <code>realm</code> | <code>[Realm1?](Models/Enums/Realm1.cs)</code> | - |
| <code>refreshToken</code> | <code>string?</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[OauthAccessTokenResponse](Models/OauthAccessTokenResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[CreateAccessTokenError](Errors/CreateAccessTokenError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## SoundEffects

> Source: [SoundEffects](Api/SoundEffects.cs)

<details>
<summary><code>Task&lt;SfxUrl&gt; DownloadSfx(string id, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint redownloads sound effects that you have already received a license for. The download links in the response are valid for 8 hours.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.SoundEffects.DownloadSfx(id);
    // TODO: Handle 'response' of type SfxUrl
}
catch (SdkException<DownloadSfxError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type DownloadSfxError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>id</code> | <code>string</code> | License ID |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[SfxUrl](Models/SfxUrl.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[DownloadSfxError](Errors/DownloadSfxError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;Sfx&gt; GetSfxDetails(int id, Language? language, View1? view, Library1? library, string? searchId, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint shows information about a sound effect.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.SoundEffects.GetSfxDetails(id, language, view, library, searchId);
    // TODO: Handle 'response' of type Sfx
}
catch (SdkException<GetSfxDetailsError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetSfxDetailsError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>id</code> | <code>int</code> | Audio track ID |
| <code>language</code> | <code>[Language?](Models/Enums/Language.cs)</code> | Language for the keywords and categories in the response |
| <code>view</code> | <code>[View1?](Models/Enums/View1.cs)</code> | Amount of detail to render in the response |
| <code>library</code> | <code>[Library1?](Models/Enums/Library1.cs)</code> | Which library to fetch from |
| <code>searchId</code> | <code>string?</code> | The ID of the search that is related to this request |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[Sfx](Models/Sfx.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetSfxDetailsError](Errors/GetSfxDetailsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;DownloadHistoryDataList&gt; GetSfxLicenseList(string? sfxId, string? license, Sort1? sort, string? username, DateTimeOffset? startDate, DateTimeOffset? endDate, string? licenseId, DownloadAvailability? downloadAvailability, int? page = 1, int? perPage = 20, bool? teamHistory = false, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint lists existing licenses.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.SoundEffects.GetSfxLicenseList(sfxId,
        license,
        sort,
        username,
        startDate,
        endDate,
        licenseId,
        downloadAvailability);
    // TODO: Handle 'response' of type DownloadHistoryDataList
}
catch (SdkException<GetSfxLicenseListError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetSfxLicenseListError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>sfxId</code> | <code>string?</code> | Show licenses for the specified sound effects ID |
| <code>license</code> | <code>string?</code> | Show sound effects that are available with the specified license, such as `standard` or `enhanced`; prepending a `-` sign excludes results from that license |
| <code>sort</code> | <code>[Sort1?](Models/Enums/Sort1.cs)</code> | Sort order |
| <code>username</code> | <code>string?</code> | Filter licenses by username of licensee |
| <code>startDate</code> | <code>DateTimeOffset?</code> | Show licenses created on or after the specified date |
| <code>endDate</code> | <code>DateTimeOffset?</code> | Show licenses created before the specified date |
| <code>licenseId</code> | <code>string?</code> | Filter by the license ID |
| <code>downloadAvailability</code> | <code>[DownloadAvailability?](Models/Enums/DownloadAvailability.cs)</code> | Filter licenses by download availability |
| <code>page</code> | <code>int?</code> | Page number<br>**Default**: 1 |
| <code>perPage</code> | <code>int?</code> | Number of results per page<br>**Default**: 20 |
| <code>teamHistory</code> | <code>bool?</code> | Set to true to see license history for all members of your team.<br>**Default**: false |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[DownloadHistoryDataList](Models/DownloadHistoryDataList.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetSfxLicenseListError](Errors/GetSfxLicenseListError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;SfxdataList&gt; GetSfxListDetails(IReadOnlyList&lt;string&gt; id, View1? view, Language? language, Library1? library, string? searchId, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint shows information about sound effects.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.SoundEffects.GetSfxListDetails(id, view, language, library, searchId);
    // TODO: Handle 'response' of type SfxdataList
}
catch (SdkException<GetSfxListDetailsError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetSfxListDetailsError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>id</code> | <code>IReadOnlyList&lt;string&gt;</code> | One or more sound effect IDs |
| <code>view</code> | <code>[View1?](Models/Enums/View1.cs)</code> | Amount of detail to render in the response |
| <code>language</code> | <code>[Language?](Models/Enums/Language.cs)</code> | Language for the keywords and categories in the response |
| <code>library</code> | <code>[Library1?](Models/Enums/Library1.cs)</code> | Which library to fetch from |
| <code>searchId</code> | <code>string?</code> | The ID of the search that is related to this request |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[SfxdataList](Models/SfxdataList.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetSfxListDetailsError](Errors/GetSfxListDetailsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;LicenseSfxresultDataList&gt; LicensesSfx(LicenseSfxrequest body, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint licenses sounds effect assets.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.SoundEffects.LicensesSfx(body);
    // TODO: Handle 'response' of type LicenseSfxresultDataList
}
catch (SdkException<LicensesSfxError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type LicensesSfxError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>body</code> | <code>[LicenseSfxrequest](Models/LicenseSfxrequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[LicenseSfxresultDataList](Models/LicenseSfxresultDataList.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[LicensesSfxError](Errors/LicensesSfxError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;SfxsearchResults&gt; SearchSfx(DateTimeOffset? addedDate, DateTimeOffset? addedDateStart, DateTimeOffset? addedDateEnd, int? duration, int? durationFrom, int? durationTo, string? query, Sort21? sort, View1? view, Language? language, int? page = 1, int? perPage = 20, bool? safe = true, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint searches for sound effects. If you specify more than one search parameter, the API uses an AND condition.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.SoundEffects.SearchSfx(addedDate,
        addedDateStart,
        addedDateEnd,
        duration,
        durationFrom,
        durationTo,
        query,
        sort,
        view,
        language);
    // TODO: Handle 'response' of type SfxsearchResults
}
catch (SdkException<SearchSfxError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type SearchSfxError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>addedDate</code> | <code>DateTimeOffset?</code> | Show sound effects added on the specified date |
| <code>addedDateStart</code> | <code>DateTimeOffset?</code> | Show sound effects added on or after the specified date |
| <code>addedDateEnd</code> | <code>DateTimeOffset?</code> | Show sound effects added before the specified date |
| <code>duration</code> | <code>int?</code> | Show sound effects with the specified duration in seconds |
| <code>durationFrom</code> | <code>int?</code> | Show sound effects with the specified duration or longer in seconds |
| <code>durationTo</code> | <code>int?</code> | Show sound effects with the specified duration or shorter in seconds |
| <code>query</code> | <code>string?</code> | One or more search terms separated by spaces |
| <code>sort</code> | <code>[Sort21?](Models/Enums/Sort21.cs)</code> | Sort by |
| <code>view</code> | <code>[View1?](Models/Enums/View1.cs)</code> | Amount of detail to render in the response |
| <code>language</code> | <code>[Language?](Models/Enums/Language.cs)</code> | Set query and result language (uses Accept-Language header if not set) |
| <code>page</code> | <code>int?</code> | Page number<br>**Default**: 1 |
| <code>perPage</code> | <code>int?</code> | Number of results per page<br>**Default**: 20 |
| <code>safe</code> | <code>bool?</code> | Enable or disable safe search<br>**Default**: true |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[SfxsearchResults](Models/SfxsearchResults.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[SearchSfxError](Errors/SearchSfxError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Test

> Source: [Test](Api/Test.cs)

<details>
<summary><code>Task&lt;TestEcho&gt; Echo(string? text = "ok", CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Test.Echo();
    // TODO: Handle 'response' of type TestEcho
}
catch (SdkException<EchoError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type EchoError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>text</code> | <code>string?</code> | Text to echo<br>**Default**: "ok" |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[TestEcho](Models/TestEcho.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[EchoError](Errors/EchoError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;TestValidate&gt; Validate(int id, IReadOnlyList&lt;string&gt;? tag, string? userAgent, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Test.Validate(id, tag, userAgent);
    // TODO: Handle 'response' of type TestValidate
}
catch (SdkException<ValidateError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type ValidateError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>id</code> | <code>int</code> | Integer ID |
| <code>tag</code> | <code>IReadOnlyList&lt;string&gt;?</code> | List of tags |
| <code>userAgent</code> | <code>string?</code> | User agent |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[TestValidate](Models/TestValidate.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[ValidateError](Errors/ValidateError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Users

> Source: [Users](Api/Users.cs)

<details>
<summary><code>Task&lt;AccessTokenDetails&gt; GetAccessToken(CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Users.GetAccessToken();
    // TODO: Handle 'response' of type AccessTokenDetails
}
catch (SdkException<GetAccessTokenError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetAccessTokenError
    }
}
```

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[AccessTokenDetails](Models/AccessTokenDetails.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetAccessTokenError](Errors/GetAccessTokenError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;UserDetails&gt; GetUser(CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Users.GetUser();
    // TODO: Handle 'response' of type UserDetails
}
catch (SdkException<GetUserError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetUserError
    }
}
```

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[UserDetails](Models/UserDetails.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetUserError](Errors/GetUserError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;SubscriptionDataList&gt; GetUserSubscriptionList(CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Users.GetUserSubscriptionList();
    // TODO: Handle 'response' of type SubscriptionDataList
}
catch (SdkException<GetUserSubscriptionListError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetUserSubscriptionListError
    }
}
```

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[SubscriptionDataList](Models/SubscriptionDataList.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetUserSubscriptionListError](Errors/GetUserSubscriptionListError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Videos

> Source: [Videos](Api/Videos.cs)

<details>
<summary><code>Task AddVideoCollectionItems(string id, CollectionItemRequest body, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint adds one or more videos to a collection by video IDs.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    await client.Videos.AddVideoCollectionItems(id, body);
}
catch (SdkException<AddVideoCollectionItemsError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type AddVideoCollectionItemsError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>id</code> | <code>string</code> | The ID of the collection to which items should be added |
| <code>body</code> | <code>[CollectionItemRequest](Models/CollectionItemRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: No content

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[AddVideoCollectionItemsError](Errors/AddVideoCollectionItemsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CollectionCreateResponse&gt; CreateVideoCollection(CollectionCreateRequest body, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint creates one or more collections (clipboxes). To add videos to collections, use `POST /v2/videos/collections/{id}/items`.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Videos.CreateVideoCollection(body);
    // TODO: Handle 'response' of type CollectionCreateResponse
}
catch (SdkException<CreateVideoCollectionError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type CreateVideoCollectionError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>body</code> | <code>[CollectionCreateRequest](Models/CollectionCreateRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CollectionCreateResponse](Models/CollectionCreateResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[CreateVideoCollectionError](Errors/CreateVideoCollectionError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task DeleteVideoCollection(string id, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint deletes a collection.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    await client.Videos.DeleteVideoCollection(id);
}
catch (SdkException<DeleteVideoCollectionError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type DeleteVideoCollectionError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>id</code> | <code>string</code> | The ID of the collection to delete |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: No content

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[DeleteVideoCollectionError](Errors/DeleteVideoCollectionError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task DeleteVideoCollectionItems(string id, IReadOnlyList&lt;string&gt;? itemId, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint removes one or more videos from a collection.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    await client.Videos.DeleteVideoCollectionItems(id, itemId);
}
catch (SdkException<DeleteVideoCollectionItemsError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type DeleteVideoCollectionItemsError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>id</code> | <code>string</code> | The ID of the Collection from which items will be deleted |
| <code>itemId</code> | <code>IReadOnlyList&lt;string&gt;?</code> | One or more video IDs to remove from the collection |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: No content

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[DeleteVideoCollectionItemsError](Errors/DeleteVideoCollectionItemsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;Url&gt; DownloadVideos(string id, RedownloadVideo body, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint redownloads videos that you have already received a license for.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Videos.DownloadVideos(id, body);
    // TODO: Handle 'response' of type Url
}
catch (SdkException<DownloadVideosError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type DownloadVideosError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>id</code> | <code>string</code> | The license ID of the item to (re)download. The download links in the response are valid for 8 hours. |
| <code>body</code> | <code>[RedownloadVideo](Models/RedownloadVideo.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[Url](Models/Url.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[DownloadVideosError](Errors/DownloadVideosError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;VideoSearchResults&gt; FindSimilarVideos(string id, Language? language, View1? view, int? page = 1, int? perPage = 20, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint searches for videos that are similar to a video that you specify.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Videos.FindSimilarVideos(id, language, view);
    // TODO: Handle 'response' of type VideoSearchResults
}
catch (SdkException<FindSimilarVideosError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type FindSimilarVideosError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>id</code> | <code>string</code> | The ID of a video for which similar videos should be returned |
| <code>language</code> | <code>[Language?](Models/Enums/Language.cs)</code> | Language for the keywords and categories in the response |
| <code>view</code> | <code>[View1?](Models/Enums/View1.cs)</code> | Amount of detail to render in the response |
| <code>page</code> | <code>int?</code> | Page number<br>**Default**: 1 |
| <code>perPage</code> | <code>int?</code> | Number of results per page<br>**Default**: 20 |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[VideoSearchResults](Models/VideoSearchResults.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[FindSimilarVideosError](Errors/FindSimilarVideosError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;FeaturedCollection&gt; GetFeaturedVideoCollection(string id, Embed3? embed, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint gets more detailed information about a featured video collection, including its cover video and timestamps for its creation and most recent update. To get the videos, use `GET /v2/videos/collections/featured/{id}/items`.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Videos.GetFeaturedVideoCollection(id, embed);
    // TODO: Handle 'response' of type FeaturedCollection
}
catch (SdkException<GetFeaturedVideoCollectionError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetFeaturedVideoCollectionError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>id</code> | <code>string</code> | Collection ID |
| <code>embed</code> | <code>[Embed3?](Models/Enums/Embed3.cs)</code> | What information to include in the response, such as a URL to the collection |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[FeaturedCollection](Models/FeaturedCollection.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetFeaturedVideoCollectionError](Errors/GetFeaturedVideoCollectionError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;VideoCollectionItemDataList&gt; GetFeaturedVideoCollectionItems(string id, int? page = 1, int? perPage = 100, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint lists the IDs of videos in a featured collection and the date that each was added.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Videos.GetFeaturedVideoCollectionItems(id);
    // TODO: Handle 'response' of type VideoCollectionItemDataList
}
catch (SdkException<GetFeaturedVideoCollectionItemsError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetFeaturedVideoCollectionItemsError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>id</code> | <code>string</code> | Collection ID |
| <code>page</code> | <code>int?</code> | Page number<br>**Default**: 1 |
| <code>perPage</code> | <code>int?</code> | Number of results per page<br>**Default**: 100 |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[VideoCollectionItemDataList](Models/VideoCollectionItemDataList.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetFeaturedVideoCollectionItemsError](Errors/GetFeaturedVideoCollectionItemsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;FeaturedCollectionDataList&gt; GetFeaturedVideoCollectionList(Embed3? embed, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint lists featured video collections and a name and cover video for each collection.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Videos.GetFeaturedVideoCollectionList(embed);
    // TODO: Handle 'response' of type FeaturedCollectionDataList
}
catch (SdkException<GetFeaturedVideoCollectionListError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetFeaturedVideoCollectionListError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>embed</code> | <code>[Embed3?](Models/Enums/Embed3.cs)</code> | What information to include in the response, such as a URL to the collection |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[FeaturedCollectionDataList](Models/FeaturedCollectionDataList.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetFeaturedVideoCollectionListError](Errors/GetFeaturedVideoCollectionListError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;UpdatedMediaDataList&gt; GetUpdatedVideos(DateTimeOffset? startDate, DateTimeOffset? endDate, Sort1? sort, string? interval = "1 HOUR", int? page = 1, int? perPage = 100, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint lists videos that have been updated in the specified time period to update content management systems (CMS) or digital asset management (DAM) systems. In most cases, use the `interval` parameter to show videos that were updated recently, but you can also use the `start_date` and `end_date` parameters to specify a range of no more than three days. Do not use the `interval` parameter with either `start_date` or `end_date`.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Videos.GetUpdatedVideos(startDate, endDate, sort);
    // TODO: Handle 'response' of type UpdatedMediaDataList
}
catch (SdkException<RawError> ex)
{
    // TODO: Handle 'ex.Error' of type RawError
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>startDate</code> | <code>DateTimeOffset?</code> | Show videos updated on or after the specified date |
| <code>endDate</code> | <code>DateTimeOffset?</code> | Show videos updated before the specified date |
| <code>sort</code> | <code>[Sort1?](Models/Enums/Sort1.cs)</code> | Sort by oldest or newest videos first |
| <code>interval</code> | <code>string?</code> | Show videos updated in the specified time period, where the time period is an interval (like SQL INTERVAL) such as 1 DAY, 6 HOUR, or 30 MINUTE; the default is 1 HOUR, which shows videos that were updated in the hour preceding the request<br>**Default**: "1 HOUR" |
| <code>page</code> | <code>int?</code> | Page number<br>**Default**: 1 |
| <code>perPage</code> | <code>int?</code> | Number of results per page<br>**Default**: 100 |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[UpdatedMediaDataList](Models/UpdatedMediaDataList.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[RawError](Core/ErrorResponse/RawError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;Video&gt; GetVideo(string id, Language? language, View1? view, string? searchId, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint shows information about a video, including URLs to previews and the sizes that it is available in.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Videos.GetVideo(id, language, view, searchId);
    // TODO: Handle 'response' of type Video
}
catch (SdkException<GetVideoError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetVideoError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>id</code> | <code>string</code> | Video ID |
| <code>language</code> | <code>[Language?](Models/Enums/Language.cs)</code> | Language for the keywords and categories in the response |
| <code>view</code> | <code>[View1?](Models/Enums/View1.cs)</code> | Amount of detail to render in the response |
| <code>searchId</code> | <code>string?</code> | The ID of the search that is related to this request |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[Video](Models/Video.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetVideoError](Errors/GetVideoError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;Collection&gt; GetVideoCollection(string id, IReadOnlyList&lt;Embed&gt;? embed, string? shareCode, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint gets more detailed information about a collection, including the timestamp for its creation and the number of videos in it. To get the videos in collections, use GET /v2/videos/collections/{id}/items.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Videos.GetVideoCollection(id, embed, shareCode);
    // TODO: Handle 'response' of type Collection
}
catch (SdkException<GetVideoCollectionError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetVideoCollectionError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>id</code> | <code>string</code> | The ID of the collection to return |
| <code>embed</code> | <code>IReadOnlyList&lt;[Embed](Models/Enums/Embed.cs)&gt;?</code> | Which sharing information to include in the response, such as a URL to the collection |
| <code>shareCode</code> | <code>string?</code> | Code to retrieve a shared collection |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[Collection](Models/Collection.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetVideoCollectionError](Errors/GetVideoCollectionError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CollectionItemDataList&gt; GetVideoCollectionItems(string id, string? shareCode, Sort1? sort, int? page = 1, int? perPage = 100, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint lists the IDs of videos in a collection and the date that each was added.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Videos.GetVideoCollectionItems(id, shareCode, sort);
    // TODO: Handle 'response' of type CollectionItemDataList
}
catch (SdkException<GetVideoCollectionItemsError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetVideoCollectionItemsError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>id</code> | <code>string</code> | Collection ID |
| <code>shareCode</code> | <code>string?</code> | Code to retrieve the contents of a shared collection |
| <code>sort</code> | <code>[Sort1?](Models/Enums/Sort1.cs)</code> | Sort order |
| <code>page</code> | <code>int?</code> | Page number<br>**Default**: 1 |
| <code>perPage</code> | <code>int?</code> | Number of results per page<br>**Default**: 100 |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CollectionItemDataList](Models/CollectionItemDataList.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetVideoCollectionItemsError](Errors/GetVideoCollectionItemsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CollectionDataList&gt; GetVideoCollectionList(IReadOnlyList&lt;Embed&gt;? embed, int? page = 1, int? perPage = 100, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint lists your collections of videos and their basic attributes.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Videos.GetVideoCollectionList(embed);
    // TODO: Handle 'response' of type CollectionDataList
}
catch (SdkException<GetVideoCollectionListError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetVideoCollectionListError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>embed</code> | <code>IReadOnlyList&lt;[Embed](Models/Enums/Embed.cs)&gt;?</code> | Which sharing information to include in the response, such as a URL to the collection |
| <code>page</code> | <code>int?</code> | Page number<br>**Default**: 1 |
| <code>perPage</code> | <code>int?</code> | Number of results per page<br>**Default**: 100 |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CollectionDataList](Models/CollectionDataList.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetVideoCollectionListError](Errors/GetVideoCollectionListError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;DownloadHistoryDataList&gt; GetVideoLicenseList(string? videoId, string? license, Sort1? sort, string? username, DateTimeOffset? startDate, DateTimeOffset? endDate, DownloadAvailability? downloadAvailability, int? page = 1, int? perPage = 20, bool? teamHistory = false, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint lists existing licenses.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Videos.GetVideoLicenseList(videoId,
        license,
        sort,
        username,
        startDate,
        endDate,
        downloadAvailability);
    // TODO: Handle 'response' of type DownloadHistoryDataList
}
catch (SdkException<GetVideoLicenseListError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetVideoLicenseListError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>videoId</code> | <code>string?</code> | Show licenses for the specified video ID |
| <code>license</code> | <code>string?</code> | Show videos that are available with the specified license, such as `standard` or `enhanced`; prepending a `-` sign excludes results from that license |
| <code>sort</code> | <code>[Sort1?](Models/Enums/Sort1.cs)</code> | Sort by oldest or newest videos first |
| <code>username</code> | <code>string?</code> | Filter licenses by username of licensee |
| <code>startDate</code> | <code>DateTimeOffset?</code> | Show licenses created on or after the specified date |
| <code>endDate</code> | <code>DateTimeOffset?</code> | Show licenses created before the specified date |
| <code>downloadAvailability</code> | <code>[DownloadAvailability?](Models/Enums/DownloadAvailability.cs)</code> | Filter licenses by download availability |
| <code>page</code> | <code>int?</code> | Page number<br>**Default**: 1 |
| <code>perPage</code> | <code>int?</code> | Number of results per page<br>**Default**: 20 |
| <code>teamHistory</code> | <code>bool?</code> | Set to true to see license history for all members of your team.<br>**Default**: false |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[DownloadHistoryDataList](Models/DownloadHistoryDataList.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetVideoLicenseListError](Errors/GetVideoLicenseListError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;VideoDataList&gt; GetVideoList(IReadOnlyList&lt;string&gt; id, View1? view, string? searchId, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint lists information about one or more videos, including the aspect ratio and URLs to previews.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Videos.GetVideoList(id, view, searchId);
    // TODO: Handle 'response' of type VideoDataList
}
catch (SdkException<GetVideoListError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetVideoListError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>id</code> | <code>IReadOnlyList&lt;string&gt;</code> | One or more video IDs |
| <code>view</code> | <code>[View1?](Models/Enums/View1.cs)</code> | Amount of detail to render in the response |
| <code>searchId</code> | <code>string?</code> | The ID of the search that is related to this request |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[VideoDataList](Models/VideoDataList.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetVideoListError](Errors/GetVideoListError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;Suggestions&gt; GetVideoSuggestions(string query, int? limit = 10, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint provides autocomplete suggestions for partial search terms.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Videos.GetVideoSuggestions(query);
    // TODO: Handle 'response' of type Suggestions
}
catch (SdkException<GetVideoSuggestionsError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type GetVideoSuggestionsError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>query</code> | <code>string</code> | Search term for which you want keyword suggestions |
| <code>limit</code> | <code>int?</code> | Limit the number of the suggestions<br>**Default**: 10 |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[Suggestions](Models/Suggestions.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetVideoSuggestionsError](Errors/GetVideoSuggestionsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;LicenseVideoResultDataList&gt; LicenseVideos(string? subscriptionId, Size9? size, string? searchId, LicenseVideoRequest body, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint gets licenses for one or more videos. You must specify the video IDs in the body parameter and the size and subscription ID either in the query parameter or with each video ID in the body parameter. Values in the body parameter override values in the query parameters. The download links in the response are valid for 8 hours.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Videos.LicenseVideos(subscriptionId, size, searchId, body);
    // TODO: Handle 'response' of type LicenseVideoResultDataList
}
catch (SdkException<LicenseVideosError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type LicenseVideosError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>subscriptionId</code> | <code>string?</code> | The subscription ID to use for licensing |
| <code>size</code> | <code>[Size9?](Models/Enums/Size9.cs)</code> | The size of the video to license |
| <code>searchId</code> | <code>string?</code> | The Search ID that led to this licensing event |
| <code>body</code> | <code>[LicenseVideoRequest](Models/LicenseVideoRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[LicenseVideoResultDataList](Models/LicenseVideoResultDataList.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[LicenseVideosError](Errors/LicenseVideosError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CategoryDataList&gt; ListVideoCategories(Language? language, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint lists the categories (Shutterstock-assigned genres) that videos can belong to.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Videos.ListVideoCategories(language);
    // TODO: Handle 'response' of type CategoryDataList
}
catch (SdkException<ListVideoCategoriesError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type ListVideoCategoriesError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>language</code> | <code>[Language?](Models/Enums/Language.cs)</code> | Language for the keywords and categories in the response |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CategoryDataList](Models/CategoryDataList.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[ListVideoCategoriesError](Errors/ListVideoCategoriesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task RenameVideoCollection(string id, CollectionUpdateRequest body, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint sets a new name for a collection.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    await client.Videos.RenameVideoCollection(id, body);
}
catch (SdkException<RenameVideoCollectionError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type RenameVideoCollectionError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>id</code> | <code>string</code> | The ID of the collection to rename |
| <code>body</code> | <code>[CollectionUpdateRequest](Models/CollectionUpdateRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: No content

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[RenameVideoCollectionError](Errors/RenameVideoCollectionError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;VideoSearchResults&gt; SearchVideos(DateTimeOffset? addedDate, DateTimeOffset? addedDateStart, DateTimeOffset? addedDateEnd, AspectRatio? aspectRatio, string? category, IReadOnlyList&lt;string&gt;? contributor, IReadOnlyList&lt;string&gt;? contributorCountry, int? duration, int? durationFrom, int? durationTo, double? fps, double? fpsFrom, double? fpsTo, Language? language, IReadOnlyList&lt;License5&gt;? license, IReadOnlyList&lt;string&gt;? model, PeopleAge1? peopleAge, IReadOnlyList&lt;PeopleEthnicity3&gt;? peopleEthnicity, PeopleGender1? peopleGender, int? peopleNumber, bool? peopleModelReleased, string? query, Resolution? resolution, Sort4? sort, View1? view, bool? keywordSafeSearch = true, int? page = 1, int? perPage = 20, bool? safe = true, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

This endpoint searches for videos. If you specify more than one search parameter, the API uses an AND condition. Array parameters can be specified multiple times; in this case, the API uses an AND or an OR condition with those values, depending on the parameter. You can also filter search terms out in the `query` parameter by prefixing the term with NOT.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Videos.SearchVideos(addedDate,
        addedDateStart,
        addedDateEnd,
        aspectRatio,
        category,
        contributor,
        contributorCountry,
        duration,
        durationFrom,
        durationTo,
        fps,
        fpsFrom,
        fpsTo,
        language,
        license,
        model,
        peopleAge,
        peopleEthnicity,
        peopleGender,
        peopleNumber,
        peopleModelReleased,
        query,
        resolution,
        sort,
        view);
    // TODO: Handle 'response' of type VideoSearchResults
}
catch (SdkException<SearchVideosError> ex)
{
    if (ex.Error.TryGetError(out var error))
    {
        // TODO: Handle 'error' of type SearchVideosError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>addedDate</code> | <code>DateTimeOffset?</code> | Show videos added on the specified date |
| <code>addedDateStart</code> | <code>DateTimeOffset?</code> | Show videos added on or after the specified date |
| <code>addedDateEnd</code> | <code>DateTimeOffset?</code> | Show videos added before the specified date |
| <code>aspectRatio</code> | <code>[AspectRatio?](Models/Enums/AspectRatio.cs)</code> | Show videos with the specified aspect ratio |
| <code>category</code> | <code>string?</code> | Show videos with the specified Shutterstock-defined category; specify a category name or ID |
| <code>contributor</code> | <code>IReadOnlyList&lt;string&gt;?</code> | Show videos with the specified artist names or IDs |
| <code>contributorCountry</code> | <code>IReadOnlyList&lt;string&gt;?</code> | Show videos from contributors in one or more specified countries |
| <code>duration</code> | <code>int?</code> | (Deprecated; use duration_from and duration_to instead) Show videos with the specified duration in seconds |
| <code>durationFrom</code> | <code>int?</code> | Show videos with the specified duration or longer in seconds |
| <code>durationTo</code> | <code>int?</code> | Show videos with the specified duration or shorter in seconds |
| <code>fps</code> | <code>double?</code> | (Deprecated; use fps_from and fps_to instead) Show videos with the specified frames per second |
| <code>fpsFrom</code> | <code>double?</code> | Show videos with the specified frames per second or more |
| <code>fpsTo</code> | <code>double?</code> | Show videos with the specified frames per second or fewer |
| <code>language</code> | <code>[Language?](Models/Enums/Language.cs)</code> | Set query and result language (uses Accept-Language header if not set) |
| <code>license</code> | <code>IReadOnlyList&lt;[License5](Models/Enums/License5.cs)&gt;?</code> | Show only videos with the specified license or licenses |
| <code>model</code> | <code>IReadOnlyList&lt;string&gt;?</code> | Show videos with each of the specified models |
| <code>peopleAge</code> | <code>[PeopleAge1?](Models/Enums/PeopleAge1.cs)</code> | Show videos that feature people of the specified age range |
| <code>peopleEthnicity</code> | <code>IReadOnlyList&lt;[PeopleEthnicity3](Models/Enums/PeopleEthnicity3.cs)&gt;?</code> | Show videos with people of the specified ethnicities |
| <code>peopleGender</code> | <code>[PeopleGender1?](Models/Enums/PeopleGender1.cs)</code> | Show videos with people with the specified gender |
| <code>peopleNumber</code> | <code>int?</code> | Show videos with the specified number of people |
| <code>peopleModelReleased</code> | <code>bool?</code> | Show only videos of people with a signed model release |
| <code>query</code> | <code>string?</code> | One or more search terms separated by spaces; you can use NOT to filter out videos that match a term |
| <code>resolution</code> | <code>[Resolution?](Models/Enums/Resolution.cs)</code> | Show videos with the specified resolution |
| <code>sort</code> | <code>[Sort4?](Models/Enums/Sort4.cs)</code> | Sort by one of these categories |
| <code>view</code> | <code>[View1?](Models/Enums/View1.cs)</code> | Amount of detail to render in the response |
| <code>keywordSafeSearch</code> | <code>bool?</code> | Hide results with potentially unsafe keywords<br>**Default**: true |
| <code>page</code> | <code>int?</code> | Page number<br>**Default**: 1 |
| <code>perPage</code> | <code>int?</code> | Number of results per page<br>**Default**: 20 |
| <code>safe</code> | <code>bool?</code> | Enable or disable safe search<br>**Default**: true |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[VideoSearchResults](Models/VideoSearchResults.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[SearchVideosError](Errors/SearchVideosError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

