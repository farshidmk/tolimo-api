using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace NOET.UET.Domain.Booklet.Enums;

/// <summary>
/// نوع بخش نمایشی در سوال.
/// مشخص‌کننده نقش محتوای متنی، صوتی یا تصویری در ساختار آزمون.
/// </summary>
[Serializable]
[DataContract]
[XmlType(TypeName = "PassageType")]
public enum PassageType : byte
{
    /// <summary>
    ///     قسمتی از سوال است بدون دیده شدن سوال، پخش میشود(متن، تصویر یا صوت)
    ///     معمولا برای تصویر و صوت به کار میرود
    /// </summary>
    [EnumMember]
    [XmlEnum("1")]
    Lecture,

    /// <summary>
    ///   خود سوال است
    /// </summary>
    [EnumMember]
    [XmlEnum("2")]
    Question,

    /// <summary>
    ///   قسمتی از سوال است. نباید در صفحه تغییر وضعیت داد
    /// </summary>
    [EnumMember]
    [XmlEnum("3")]
    StopMedia,

    /// <summary>
    /// بخش درک مطلب یا Reading.
    /// معمولاً شامل متن طولانی برای تحلیل یا پاسخ‌دهی.
    /// </summary>
    [EnumMember]
    [XmlEnum("4")]
    Reading
}