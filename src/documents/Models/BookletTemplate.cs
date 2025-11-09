using NOET.UET.Domain.Booklet.Enums;
using NOET.UET.Shared.Models.Primitives;
using NOET.UET.Shared.Validation.Interfaces;
using NOET.UET.Shared.Validation.Models;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace NOET.UET.Domain.Booklet.Models;
/// <summary>
/// هدف: تعریف ساختار پایه‌ای دفترچه برای تولید نسخه‌های مختلف
/// الگوی پایه برای تولید دفترچه‌های آزمون.
/// شامل ساختار منطقی بخش‌ها، نوع آزمون، و زمان پیش‌فرض.
/// این مدل مستقل از زبان و نسخه است.
/// </summary>
[Serializable]
[DataContract]
[XmlType(TypeName = "BookletTemplate")]
[XmlRoot(ElementName = "BookletTemplateRoot")]
public class BookletTemplate : DataPrimitive, IValidatable
{
    /// <summary>
    /// شناسه یکتا برای الگوی دفترچه.
    /// </summary>
    [XmlAttribute("TemplateId")]
    [DataMember]
    public Guid TemplateId { get; set; }

    /// <summary>
    /// نام الگوی دفترچه برای نمایش یا مدیریت.
    /// </summary>
    [XmlAttribute("TemplateName")]
    [DataMember]
    public string TemplateName { get; set; } = "";

    /// <summary>
    /// نوع آزمون مرتبط با این الگو (استاندارد، تطبیقی، تمرینی...).
    /// </summary>
    [XmlAttribute("TestType")]
    [DataMember]
    public TestType TestType { get; set; }

    /// <summary>
    /// زمان پیش‌فرض برای کل دفترچه آزمون.
    /// </summary>
    [XmlAttribute("DefaultDuration")]
    [DataMember]
    public TimeSpan DefaultDuration { get; set; }

    /// <summary>
    /// لیست بخش‌های تعریف‌شده در الگو.
    /// هر بخش شامل سوالات و تنظیمات خاص خود است.
    /// </summary>
    [XmlElement("Section")]
    [DataMember]
    public List<BookletSection> Sections { get; set; } = new();

    /// <summary>
    /// اعتبارسنجی ساختار الگو برای اطمینان از کامل بودن داده‌ها.
    /// </summary>
    public override List<ValidationError> Validate()
    {
        var errors = new List<ValidationError>();

        if (string.IsNullOrWhiteSpace(TemplateName))
            errors.Add(new("TemplateName", "Empty", "Template name is required."));

        if (Sections.Count == 0)
            errors.Add(new("Sections", "Empty", "Template must contain at least one section."));

        return errors;
    }
}
