using NOET.UET.Shared.Models.Primitives;
using NOET.UET.Shared.Validation.Interfaces;
using NOET.UET.Shared.Validation.Models;
using System.Runtime.Serialization;
using System.Xml.Serialization;
namespace NOET.UET.Domain.Booklet.Models;
/// <summary>
/// هدف: تولید نسخه ترجمه‌شده از دفترچه برای زبان‌های مختلف
/// نسخه ترجمه‌شده از دفترچه آزمون.
/// شامل محتوای متنی به زبان خاص و اطلاعات ترجمه.
/// </summary>
[Serializable]
[DataContract]
[XmlType(TypeName = "LocalizedBooklet")]
[XmlRoot(ElementName = "LocalizedBookletRoot")]
public class LocalizedBooklet : DataPrimitive, IValidatable
{
    /// <summary>
    /// شناسه دفترچه پایه که این نسخه از آن ترجمه شده است.
    /// </summary>
    [XmlAttribute("BaseBookletId")]
    [DataMember]
    public Guid BaseBookletId { get; set; }

    /// <summary>
    /// کد زبان ترجمه‌شده (مثلاً "fa", "en", "de").
    /// </summary>
    [XmlAttribute("LanguageCode")]
    [DataMember]
    public string LanguageCode { get; set; } = "en";

    /// <summary>
    /// نام یا شناسه مترجم یا سیستم ترجمه.
    /// </summary>
    [XmlAttribute("TranslatedBy")]
    [DataMember]
    public string? TranslatedBy { get; set; }

    /// <summary>
    /// لیست بخش‌های ترجمه‌شده شامل سوالات و منابع.
    /// </summary>
    [XmlElement("Section")]
    [DataMember]
    public List<BookletSection> TranslatedSections { get; set; } = new();

    /// <summary>
    /// اعتبارسنجی ساختار ترجمه‌شده برای اطمینان از کامل بودن محتوا.
    /// </summary>
    public List<ValidationError> Validate()
    {
        var errors = new List<ValidationError>();

        if (string.IsNullOrWhiteSpace(LanguageCode))
            errors.Add(new("LanguageCode", "Empty", "Language code is required."));

        if (TranslatedSections.Count == 0)
            errors.Add(new("TranslatedSections", "Empty", "Localized booklet must contain at least one section."));

        return errors;
    }
}
