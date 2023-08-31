using System.Text.Json.Serialization;

namespace dotnet_rpg_nd.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))] //this attribute helps present the key-value (Knight)
    public enum RpgClass
    {
        Knight = 1,
        Mage = 2,
        Cleric = 3,
    }
}
