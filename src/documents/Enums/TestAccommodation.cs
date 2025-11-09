using System.ComponentModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace NOET.UET.Domain.Booklet.Enums;

[Serializable]
[DataContract]
[Description("سوال مناسب برای افراد با نیازهای ویژه")]
public enum TestAccommodation : byte
{
    [EnumMember]
    [Description("عادی")]
    [XmlEnum("0")]
    Normal = 0,

    [EnumMember]
    [Description("کم بینا")]
    [XmlEnum("1")]
    VisuallyImpairedfield = 1
}