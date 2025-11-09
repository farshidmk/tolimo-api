using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace NOET.UET.Domain.Booklet.Enums;

/// <summary>
/// نحوه ترازبندی عناصر در فرم آزمون.
/// برای تطبیق با زبان، جهت نمایش، یا نیاز داوطلب.
/// </summary>
[Serializable]
[DataContract]
public enum FormAlignment : byte
{
    /// <summary>
    /// چپ‌چین (مناسب برای زبان‌های LTR مانند انگلیسی).
    /// </summary>
    [EnumMember]
    [XmlEnum("0")]
    LTR = 0,

    /// <summary>
    /// راست‌چین (مناسب برای زبان‌های RTL مانند فارسی).
    /// </summary>
    [EnumMember]
    [XmlEnum("1")]
    RTL = 1
}

