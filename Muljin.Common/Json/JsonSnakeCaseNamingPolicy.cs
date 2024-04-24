using System;
using System.Text.Json;

namespace Muljin.Json;

public class JsonSnakeCaseNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name)
    {
        return name.ToSnakeCase();
    }
}
