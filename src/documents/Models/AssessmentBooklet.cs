using NOET.UET.Domain.Booklet.Enums;
using NOET.UET.Shared.Models.Primitives;
using NOET.UET.Shared.Validation.Interfaces;
using NOET.UET.Shared.Validation.Models;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace NOET.UET.Domain.Booklet.Models;

[Serializable]
[DataContract]
[XmlType(TypeName = "AssessmentBooklet")]
[XmlRoot(ElementName = "AssessmentBookletRoot")]
public class AssessmentBooklet : DataPrimitive, IValidatable
{
    [XmlAttribute("ExamTitle")]
    [DataMember]
    public string ExamTitle { get; set; } = "";
    /// <summary>
    /// زمان پیش‌فرض برای کل دفترچه آزمون.
    /// </summary>
    [XmlAttribute("DefaultDuration")]
    [DataMember]
    public TimeSpan DefaultDuration { get; set; }

    [XmlAttribute("BookletName")]
    [DataMember]
    public string BookletName { get; set; } = "";

    [XmlAttribute("TestType")]
    [DataMember]
    public TestType TestType { get; set; }

    [XmlAttribute("BookletCode")]
    [DataMember]
    public string? BookletCode { get; set; }

    [XmlAttribute("ExamId")]
    [DataMember]
    public Guid ExamId { get; set; }

    [XmlAttribute("Accommodation")]
    [DataMember]
    public TestAccommodation Accommodation { get; set; }

    [XmlAttribute("Alignment")]
    [DataMember]
    public FormAlignment Alignment { get; set; }

    [XmlAttribute("Description")]
    [DataMember]
    public string Description { get; set; } = "";

    [XmlElement("Section")]
    [DataMember]
    public List<BookletSection> Sections { get; set; } = new();


    public List<ValidationError> Validate()
    {
        var errors = new List<ValidationError>();

        if (string.IsNullOrWhiteSpace(BookletName))
            errors.Add(new("BookletName", "Empty", "Booklet name is required."));

        if (Sections.Count == 0)
            errors.Add(new("Sections", "Empty", "At least one section is required."));

        return errors;
    }
}
