using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace NOET.UET.Domain.Booklet.Enums;

/// <summary>
/// نوع لیست گزینه‌های سوال.
/// مشخص‌کننده تعداد گزینه‌ها و نحوه تعامل داوطلب با آن‌ها.
/// برای کنترل رفتار نمایش، ارزیابی، و رندر فرم.
/// </summary>
[Serializable]
[DataContract]
[XmlType(TypeName = "AnswerSelectionMode")]
public enum AnswerSelectionMode
{
    /// <summary>
    /// سوال با دو گزینه انتخابی.
    /// معمولاً برای سوالات بله/خیر یا درست/نادرست.
    /// </summary>
    [EnumMember]
    [XmlEnum("m2")]
    MultiChoice2,

    /// <summary>
    /// سوال با سه گزینه انتخابی.
    /// برای سوالات با گزینه‌های محدود و ساده.
    /// </summary>
    [EnumMember]
    [XmlEnum("m3")]
    MultiChoice3,

    /// <summary>
    /// سوال با چهار گزینه انتخابی.
    /// رایج‌ترین ساختار در آزمون‌های استاندارد.
    /// </summary>
    [EnumMember]
    [XmlEnum("m4")]
    MultiChoice4,

    /// <summary>
    /// سوال تک‌گزینه‌ای.
    /// داوطلب فقط یک گزینه را می‌تواند انتخاب کند.
    /// </summary>
    [EnumMember]
    [XmlEnum("s")]
    SingleChoice,

    /// <summary>
    /// سوال تعاملی از نوع کشیدن و رها کردن.
    /// برای آزمون‌های تصویری یا مهارتی.
    /// </summary>
    [EnumMember]
    [XmlEnum("d")]
    DragAndDrop
}