using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace ManageEmployees.Models.Enums
{

    [JsonConverter(typeof(StringEnumConverter))]
    public enum JobPosition
    {
        Trainee,
        Junior,
        Senior,
        Expert,
        Manager
    }
}