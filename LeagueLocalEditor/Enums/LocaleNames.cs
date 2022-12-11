using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace LeagueLocalEditor.UI.Enums
{
    public class LocaleNames
    {
        public enum Code
        {
            invalidCode = -1,
            ja_JP,
            ko_KR,
            zh_CN,
            zh_TW,
            es_ES,
            es_MX,
            en_US = 6,
            en_GB = 6,
            en_AU = 6,
            fr_FR,
            de_DE,
            it_IT,
            pl_PL,
            ro_RO,
            el_GR,
            pt_BR,
            hu_HU,
            ru_RU,
            tr_TR
    }

        public enum Language
        {
            invalidCode = -1,
            Japanese,
            Korean,
            Chinese,
            Taiwanese,
            [Display(Name = "Spanish (Spain)")]
            SpanishES,
            [Display(Name = "Spanish (Latin America)")]
            SpanishMX,
            English,
            French,
            German,
            Italian,
            Polish,
            Romanian,
            Greek,
            Portuguese,
            Hungarian,
            Russian,
            Turkish
        }

        public Language GetLanguage(Code code)
        {
            return (Language)code;
        }

        private static bool HasDisplayName(Language language)
        {
            return language == Language.SpanishES || language == Language.SpanishMX;
        }

        public static string GetDisplayName(Language language)
        {
            if(language == Language.invalidCode)
            {
                return string.Empty;
            }
            else if (HasDisplayName(language))
            {
                var enumType = typeof(Enums.LocaleNames.Language);
                var memberInfos = enumType.GetMember(language.ToString());
                var atts = memberInfos[0].GetCustomAttributes(typeof(DisplayAttribute), false);

                if (atts.Length > 0)
                {
                    return ((DisplayAttribute)atts[0])?.Name ?? string.Empty;
                }
            }
            return language.ToString();
        }

        public static List<Tuple<string, Language>> GetAllDisplayNames()
        {
            var languages = new List<Tuple<string, Language>>();
            foreach (var language in Enum.GetValues(typeof(Enums.LocaleNames.Language)) as IEnumerable<Enums.LocaleNames.Language>)
            {
                if (HasDisplayName(language))
                {
                    languages.Add(new Tuple<string, Language>(GetDisplayName(language), language));
                }
                else
                {
                    languages.Add(new Tuple<string, Language>(language.ToString(), language));
                }
            }
            return languages;
        }
    }
}
