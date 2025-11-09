using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace NOET.UET.Domain.Booklet.Enums;

/// <summary>
/// نوع منطقی سوال در دفترچه آزمون.
/// مشخص‌کننده ساختار، رسانه، و نحوه تعامل با سوال.
/// برای تولید، اجرا، و ارزیابی استفاده می‌شود.
/// </summary>
[Serializable]
[DataContract]
public enum QuestionKind : byte
{
    /// <summary>
    /// توضیحات مربوط به بخش آزمون بدون سوال.
    /// فقط برای نمایش متن راهنما یا دستورالعمل.
    /// </summary>
    [EnumMember]
    [XmlEnum("t1")]
    SectionDirection = 1,

    /// <summary>
    /// نمایش یک متن یا منبع بدون سوال مرتبط.
    /// برای مطالعه یا آماده‌سازی.
    /// </summary>
    [EnumMember]
    [XmlEnum("t8")]
    ViewOnlyPassage = 8,

    /// <summary>
    /// سوال تعاملی از نوع Drag & Drop.
    /// معمولاً در آزمون‌های تصویری یا مهارتی.
    /// </summary>
    [EnumMember]
    [XmlEnum("t9")]
    DragAndDrop = 9,

    /// <summary>
    /// سوال تک‌گزینه‌ای بدون منبع متنی.
    /// </summary>
    [EnumMember]
    [XmlEnum("t11")]
    SingleChoice = 11,

    /// <summary>
    /// سوال چندگزینه‌ای بدون منبع متنی.
    /// </summary>
    [EnumMember]
    [XmlEnum("t12")]
    MultiChoice = 12,

    /// <summary>
    /// سوال تک‌گزینه‌ای همراه با متن یا منبع.
    /// </summary>
    [EnumMember]
    [XmlEnum("t21")]
    Reading_SingleChoice = 21,

    /// <summary>
    /// سوال چندگزینه‌ای همراه با متن یا منبع.
    /// </summary>
    [EnumMember]
    [XmlEnum("t22")]
    Reading_MultiChoice = 22,

    /// <summary>
    /// ارائه شنیداری بدون سوال.
    /// برای آماده‌سازی یا تمرین.
    /// </summary>
    [EnumMember]
    [XmlEnum("t31")]
    Listening_Lecture = 31,

    /// <summary>
    /// سوال مرتبط با ارائه شنیداری.
    /// </summary>
    [EnumMember]
    [XmlEnum("t32")]
    Listening_Question = 32,

    /// <summary>
    /// بخشی از ارائه شنیداری بدون سوال مستقیم.
    /// ممکن است شامل صوت ناقص یا تمرینی باشد.
    /// </summary>
    [EnumMember]
    [XmlEnum("t33")]
    Listening_Fragment = 33,

    /// <summary>
    /// ارائه نوشتاری بدون سوال.
    /// برای مطالعه یا تحلیل.
    /// </summary>
    [EnumMember]
    [XmlEnum("t41")]
    Writing_Lecture = 41,

    /// <summary>
    /// ارائه نوشتاری همراه با صوت یا سخنرانی.
    /// برای سوالات ترکیبی یا چندرسانه‌ای.
    /// </summary>
    [EnumMember]
    [XmlEnum("t42")]
    Writing_Lecture_WithAudio = 42,

    /// <summary>
    /// سوال گفتاری
    /// </summary>
    [EnumMember]
    [XmlEnum("t51")]
    Speaking = 51
}


///// <summary>
///// نوع آزمون.
///// برای تعیین رفتار دفترچه، ارزیابی، و نمایش.
///// </summary>
//[Serializable]
//[DataContract]
//public enum TestType : byte
//{
//    /// <summary>
//    /// آزمون تولیمو (آزمون زبان رسمی).
//    /// </summary>
//    [EnumMember]
//    [XmlEnum("3")]
//    Tolimo = 3
//}
