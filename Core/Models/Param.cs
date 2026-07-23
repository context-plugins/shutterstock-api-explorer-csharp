namespace ShutterstockApiExplorer.Core.Models;

internal readonly record struct Param(
    string Key,
    object? Value,
    SerializationFormat SerializationFormat = SerializationFormat.Plain);