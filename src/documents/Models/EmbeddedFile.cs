using NOET.UET.Domain.Booklet.Enums;
using NOET.UET.Shared.Models.Primitives;
using NOET.UET.Shared.Validation.Interfaces;
using NOET.UET.Shared.Validation.Models;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace NOET.UET.Domain.Booklet.Models;

/// <summary>
/// فایل صوتی یا تصویری مرتبط با یک بخش از سوال.
/// می‌تواند شامل تنظیمات زمان‌بندی و اشیای فرم نمایشی باشد.
/// </summary>
[Serializable]
[DataContract]
[XmlType(TypeName = "EmbeddedFile")]
public class EmbeddedFile : DataPrimitive, IValidatable
{
    ///// <summary>RG
    ///// محتوای فایل به‌صورت بایت.
    ///// می‌تواند صوت، تصویر، یا ویدئو باشد.
    ///// </summary>
    //[XmlArray(ElementName = "File")]
    //[DataMember]
    //public byte[] File { get; set; }

    /// <summary>
    /// نام فایل برای نمایش یا ذخیره‌سازی.
    /// </summary>
    [XmlAttribute("FileName")]
    [DataMember]
    public string FileName { get; set; } = "";

    /// <summary>
    /// نوع فایل (مثلاً صوت، تصویر، ویدئو).
    /// برای کنترل رفتار پخش و رندر.
    /// </summary>
    [XmlAttribute("FileType")]
    [DataMember]
    public FileType FileType { get; set; }

    /// <summary>
    /// طول مدت پخش فایل به ثانیه. اگر صفر باشد، کل فایل پخش شود
    /// </summary>
    [XmlAttribute("DurationSeconds")]
    [DataMember]
    public short DurationSeconds { get; set; }

    /// <summary>
    ///از چه زمانی از فایل پخش شود به ثانیه
    /// </summary>
    [XmlAttribute("StartSeconds")]
    [DataMember]
    public short StartSeconds { get; set; }
    /// <summary>
    /// اشیای فرم مرتبط با این فایل (مثلاً دکمه‌ها، برچسب‌ها).
    /// برای تعامل یا نمایش همزمان با فایل.
    /// </summary>
    [XmlElement("FormObject")]
    [DataMember]
    public List<FormObject> FormObjects { get; set; } = new();

    /// <summary>
    /// اعتبارسنجی ساختار فایل برای اطمینان از کامل بودن داده‌ها.
    /// </summary>
    public List<ValidationError> Validate()
    {
        var errors = new List<ValidationError>();

        if (string.IsNullOrWhiteSpace(FileName))
            errors.Add(new("FileName", "Empty", "Embedded file must have a valid name."));

        //if (File == null || File.Length == 0)
        //    errors.Add(new("File", "Missing", "Embedded file content is required."));

        return errors;
    }
}