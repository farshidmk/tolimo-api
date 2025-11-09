using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace NOET.UET.Domain.Booklet.Enums;

/// <summary>
/// نوع مجموعه سوال در دفترچه آزمون.
/// برای تفکیک ساختار بخش‌ها و اعمال منطق خاص.
/// </summary>
[Serializable]
[DataContract]
public enum SectionType : byte
{
    /// <summary>
    /// لیست سوالات عمومی.
    /// </summary>
    [EnumMember]
    [XmlEnum("1")]
    Questions = 1,

    /// <summary>
    /// بخش خواندنی (Reading).
    /// </summary>
    [EnumMember]
    [XmlEnum("2")]
    Reading = 2,

    /// <summary>
    /// بخش نوشتاری (Writing).
    /// </summary>
    [EnumMember]
    [XmlEnum("3")]
    Writing = 3,

    /// <summary>
    /// بخش شنیداری (Listening).
    /// </summary>
    [EnumMember]
    [XmlEnum("4")]
    Listening = 4,

    /// <summary>
    /// بخش گفتاری (Speaking).
    /// </summary>
    [EnumMember]
    [XmlEnum("5")]
    Speaking = 5,

    /// <summary>
    /// بخش سیستمی یا غیرقابل مشاهده.
    /// </summary>
    [EnumMember]
    [XmlEnum("0")]
    System = 0
}
