// using System.Text.Json;
// using System.Text.Json.Serialization;

// public static class ValueConversionExtensions
// {
//     public static PropertyBuilder<T> HasJsonConversion<T>(this PropertyBuilder<T> propertyBuilder) where T : class, new()
//     {
//         byte[] jsonUtf8Bytes =
//         ValueConverter<T, string> converter = new ValueConverter<T, string>
//         (
//             v => JsonSerializer.Serialize(v),
//             v = JsonSerializer.Deserialize<T>(JsonSerializer.SerializeToUtf8Bytes(v)) ?? new T()
//         );

//         ValueComparer<T> comparer = new ValueComparer<T>
//         (
//             (l, r) => JsonConvert.SerializeObject(l) == JsonConvert.SerializeObject(r),
//             v => v == null ? 0 : JsonConvert.SerializeObject(v).GetHashCode(),
//             v => JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(v))
//         );

//         propertyBuilder.HasConversion(converter);
//         propertyBuilder.Metadata.SetValueConverter(converter);
//         propertyBuilder.Metadata.SetValueComparer(comparer);

//         return propertyBuilder;
//     }
// }