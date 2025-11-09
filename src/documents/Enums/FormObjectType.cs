using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace NOET.UET.Domain.Booklet.Enums;

/// <summary>
/// انواع ابزارهای نمایشی یا تعاملی در فرم آزمون.
/// برای کنترل رفتار، نمایش، و تعامل با داوطلب.
/// </summary>
[Serializable]
[DataContract]
public enum FormObjectType : byte
{
    /// <summary>
    /// دکمه مرور کلی.
    /// </summary>
    [EnumMember]
    [XmlEnum("1")]
    Review = 1,

    /// <summary>
    /// دکمه کنترل صدا.
    /// </summary>
    [EnumMember]
    [XmlEnum("2")]
    VolumeButton,

    /// <summary>
    /// دکمه راهنما.
    /// </summary>
    [EnumMember]
    [XmlEnum("3")]
    HelpButton,

    /// <summary>
    /// دکمه قبلی.
    /// </summary>
    [EnumMember]
    [XmlEnum("4")]
    BackButton,

    /// <summary>
    /// دکمه بعدی.
    /// </summary>
    [EnumMember]
    [XmlEnum("5")]
    NextButton,

    /// <summary>
    /// دکمه ادامه.
    /// </summary>
    [EnumMember]
    [XmlEnum("6")]
    ContinueButton,

    /// <summary>
    /// برچسب نمایشی.
    /// </summary>
    [EnumMember]
    [XmlEnum("7")]
    Label,

    /// <summary>
    /// کنترل صدا (غیرفعال یا نمایشی).
    /// </summary>
    [EnumMember]
    [XmlEnum("8")]
    VolumControl,

    /// <summary>
    /// نمایش زمان آزمون.
    /// </summary>
    [EnumMember]
    [XmlEnum("9")]
    TimerLabel,

    /// <summary>
    /// دکمه پنهان کردن زمان.
    /// </summary>
    [EnumMember]
    [XmlEnum("10")]
    TimerHideButton,

    /// <summary>
    /// نمایش تعداد سوالات.
    /// </summary>
    [EnumMember]
    [XmlEnum("11")]
    QuestionLabel,

    /// <summary>
    /// دکمه مرور متن.
    /// </summary>
    [EnumMember]
    [XmlEnum("12")]
    ReviewTextButton,

    /// <summary>
    /// دکمه مرور سوالات.
    /// </summary>
    [EnumMember]
    [XmlEnum("13")]
    ReviewQuestionButton,

    /// <summary>
    /// دکمه تایید.
    /// </summary>
    [EnumMember]
    [XmlEnum("14")]
    OkButton,

    /// <summary>
    /// دکمه نشانه‌گذاری سوال.
    /// </summary>
    [EnumMember]
    [XmlEnum("15")]
    MarkButton,

    /// <summary>
    /// دکمه پرش از بخش آزمون.
    /// </summary>
    [EnumMember]
    [XmlEnum("16")]
    SkipDirection
}
