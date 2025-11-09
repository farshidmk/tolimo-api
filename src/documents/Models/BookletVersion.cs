using NOET.UET.Shared.Models.Primitives;
using NOET.UET.Shared.Validation.Interfaces;
using NOET.UET.Shared.Validation.Models;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace NOET.UET.Domain.Booklet.Models;


/// <summary>
/// هدف: تولید نسخه‌های مختلف از یک دفترچه با بخش‌های مشترک و اختصاصی
/// نسخه خاص از دفترچه آزمون.
/// شامل بخش‌های مشترک و اختصاصی برای تطبیق با نیاز داوطلب یا شرایط آزمون.
/// </summary>
[Serializable]
[DataContract]
[XmlType(TypeName = "BookletVersion")]
[XmlRoot(ElementName = "BookletVersionRoot")]
public class BookletVersion : DataPrimitive, IValidatable
{
    /// <summary>
    /// شناسه دفترچه پایه که این نسخه از آن مشتق شده است.
    /// </summary>
    [XmlAttribute("BaseBookletId")]
    [DataMember]
    public Guid BaseBookletId { get; set; }

    /// <summary>
    /// شماره نسخه برای مدیریت و تطبیق.
    /// </summary>
    [XmlAttribute("VersionNumber")]
    [DataMember]
    public int VersionNumber { get; set; }

    /// <summary>
    /// عنوان یا توضیح نسخه برای نمایش یا گزارش‌گیری.
    /// </summary>
    [XmlAttribute("VersionLabel")]
    [DataMember]
    public string VersionLabel { get; set; } = "";

    /// <summary>
    /// نام یا شناسه تولیدکننده نسخه.
    /// </summary>
    [XmlAttribute("CreatedBy")]
    [DataMember]
    public string CreatedBy { get; set; } = "";

    /// <summary>
    /// زمان تولید نسخه.
    /// </summary>
    [XmlAttribute("CreatedAt")]
    [DataMember]
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// بخش‌های مشترک بین نسخه‌ها (مثل دستورالعمل‌ها یا سوالات عمومی).
    /// </summary>
    [XmlElement("SharedSection")]
    [DataMember]
    public List<BookletSection> SharedSections { get; set; } = new();

    /// <summary>
    /// بخش‌های اختصاصی این نسخه (مثل سوالات تطبیقی یا شخصی‌سازی‌شده).
    /// </summary>
    [XmlElement("CustomSection")]
    [DataMember]
    public List<BookletSection> CustomSections { get; set; } = new();

    /// <summary>
    /// ترکیب نهایی بخش‌های مشترک و اختصاصی به ترتیب نمایش.
    /// </summary>
    public List<BookletSection> GetMergedSections()
    {
        return SharedSections.Concat(CustomSections).OrderBy(s => s.DisplayOrder).ToList();
    }

    /// <summary>
    /// اعتبارسنجی ساختار نسخه برای اطمینان از کامل بودن داده‌ها.
    /// </summary>
    public List<ValidationError> Validate()
    {
        var errors = new List<ValidationError>();

        if (VersionNumber <= 0)
            errors.Add(new("VersionNumber", "Invalid", "Version number must be positive."));

        if (string.IsNullOrWhiteSpace(VersionLabel))
            errors.Add(new("VersionLabel", "Empty", "Version label is required."));

        if (SharedSections.Count + CustomSections.Count == 0)
            errors.Add(new("Sections", "Empty", "Version must contain at least one section."));

        return errors;
    }
}
