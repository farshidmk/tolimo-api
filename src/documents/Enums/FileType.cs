using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace NOET.UET.Domain.Booklet.Enums;

/// <summary>
/// نوع فایل تعبیه‌شده در سوال یا بخش آزمون.
/// مشخص‌کننده رسانه مورد استفاده برای نمایش، پخش، یا تعامل.
/// </summary>
[Serializable]
[DataContract]
[XmlType(TypeName = "FileType")]
public enum FileType : byte
{
    /// <summary>
    /// فایل صوتی (مثلاً MP3، WAV).
    /// برای پخش شنیداری در سوالات Listening یا Speaking.
    /// </summary>
    [EnumMember]
    [XmlEnum("1")]
    Voice = 1,

    /// <summary>
    /// فایل تصویری (مثلاً PNG، JPG).
    /// برای نمایش در سوالات تصویری یا منابع دیداری.
    /// </summary>
    [EnumMember]
    [XmlEnum("2")]
    Image = 2,

    /// <summary>
    /// فایل متنی ساده (مثلاً TXT).
    /// برای نمایش مستقیم متن بدون قالب‌بندی.
    /// </summary>
    [EnumMember]
    [XmlEnum("3")]
    Text = 3,

    /// <summary>
    /// فایل متنی قالب‌دار (RTF).
    /// برای نمایش متن با قالب‌بندی، فونت، رنگ و ساختار.
    /// </summary>
    [EnumMember]
    [XmlEnum("4")]
    Rtf = 4,

    /// <summary>
    /// فایل ویدئویی (مثلاً MP4، WebM).
    /// برای پخش تصویری در سوالات چندرسانه‌ای.
    /// </summary>
    [EnumMember]
    [XmlEnum("5")]
    Video = 5,

    /// <summary>
    /// فایل PDF.
    /// برای نمایش اسناد رسمی، منابع یا دستورالعمل‌ها.
    /// </summary>
    [EnumMember]
    [XmlEnum("6")]
    Pdf = 6,

    /// <summary>
    /// قطعه HTML.
    /// برای نمایش محتوای تعاملی یا قالب‌دار در مرورگر داخلی.
    /// </summary>
    [EnumMember]
    [XmlEnum("7")]
    HtmlFragment = 7
}