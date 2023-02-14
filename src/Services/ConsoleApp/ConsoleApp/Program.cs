using ConsoleApp;

RefreshTokenId token1 = RefreshTokenId.GenerateUnique;
Name name1 = Name.CreateInstance("Bertan", "Deniz");
Name name2 = Name.CreateInstance("Bertan", "Deniz");
Console.WriteLine(name1.Equals(name2));


Console.WriteLine(CamelCaseToSnakeCase("Id"));


String CamelCaseToSnakeCase(String propertyName) {
    return String.Concat(
        propertyName.Select(
            (x, index) => index > 0 && Char.IsUpper(x) ? $"_{x}" : x.ToString()))
        .ToLowerInvariant();
}