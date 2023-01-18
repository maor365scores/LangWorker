using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebLangCreator;

[Table("T_DICT_VALUES")]
public record DictValuesRecord
{
    [Column("ID")]
    [Key]
    public long Id { get; init; }

    [Column("TERM_ID")]
    public long TermId { get; init; }

    [Column("LANG_ID")]
    public int LangId { get; init; }

    [Column("VALUE")]
    public string Value { get; init; }

    [Column("Context")]
    public string? Context { get; init; }

    [Column("IS_DEFAULT")]
    public bool IsDefault { get; init; }
}

[Table("T_DICT_TERMS")]
public record DictTermsRecord
{
    [Column("TERM_ID")]
    [Key]
    public long TermId { get; init; }

    [Column("CATEGORY_ID")]
    public int CategoryId { get; init; }

    [Column("ALIAS_NAME")]
    public string? AliasName { get; set; }

    [Column("FATHER_TERM")]
    public long? FatherTerm { get; set; }
}

[Table("T_COUNTRIES")]
public record Country
{
    [Key]
    [Column("COUNTRY_ID")]
    public int CountryId { get; init; }

    [Column("NAME_ID")]
    public long NameId { get; init; }

    [Column("COUNTRY_CODE")]
    public string CountryCode { get; init; }

    [Column("TIME_ZONE_ID")]
    public int TimeZoneId { get; init; }

    [Column("FATHER_COUNTRY_ID")]
    public int FatherCountryId { get; init; }
}

[Table("T_ATHLETES")]
public record Athlete
{
    [Key]
    [Column("ATHLETE_ID")]
    public long AthleteId { get; init; }

    [Column("NAME_ID")]
    public long NameId { get; init; }
}

[Table("T_COMPETITORS")]
public record Competitor
{
    [Key]
    [Column("COMPETITOR_ID")]
    public long CompetitorId { get; init; }

    [Column("NAME_ID")]
    public long NameId { get; init; }
}

[Table("T_COMPETITIONS")]
public record Competition
{
    [Key]
    [Column("COMPETITION_ID")]
    public long CompetitionId { get; init; }

    [Column("NAME_ID")]
    public long NameId { get; init; }
}

[Table("T_LANGUAGES")]
public record Language
{
    [Key]
    [Column("LANGUAGE_ID")]
    public int LanguageId { get; init; }

    [Column("NAME_ID")]
    public long NameId { get; init; }

    [Column("DIRECTION")]
    public short Direction { get; init; }

    [Column("CULTURE_NAME")]
    public string? CultureName { get; init; }

    [Column("ISO_2_LETTERS_CODE")]
    public string? Iso2LettersCode { get; init; }

    [Column("ISO_3_LETTERS_CODE")]
    public string? Iso3LettersCode { get; init; }

    [Column("WIN_3_LETTERS_CODE")]
    public string? Win3LettersCode { get; init; }

    [Column("FATHER_LANG_ID")]
    public int? FatherLangId { get; init; }

    [Column("LANG_TYPE")]
    public int? LangType { get; init; }

    [Column("IS_DISPLAYED")]
    public bool IsDisplayed { get; init; }
}