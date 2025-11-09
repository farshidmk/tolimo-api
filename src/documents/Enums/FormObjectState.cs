using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace NOET.UET.Domain.Booklet.Enums;

/// <summary>
/// وضعیت فعلی ابزار نمایشی.
/// برای کنترل نمایش، فعال‌سازی، یا غیرفعال‌سازی در فرم آزمون.
/// </summary>
[Serializable]
[DataContract]
public enum FormObjectState : byte
{
    /// <summary>
    /// بدون وضعیت مشخص (غیرفعال یا تعریف‌نشده).
    /// </summary>
    [EnumMember]
    [XmlEnum("0")]
    None = 0,

    /// <summary>
    /// فعال و قابل استفاده.
    /// </summary>
    [EnumMember]
    [XmlEnum("1")]
    Active = 2,

    /// <summary>
    /// غیرفعال و غیرقابل تعامل.
    /// </summary>
    [EnumMember]
    [XmlEnum("2")]
    Deactive = 3,

    /// <summary>
    /// نمایش داده نشود.
    /// </summary>
    [EnumMember]
    [XmlEnum("3")]
    NoDisplay = 1
}
