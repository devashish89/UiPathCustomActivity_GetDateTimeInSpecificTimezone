using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Activities;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using GetDateTimeInSpecificTimeZone.UiPath.Shared.Activities.Utilities;

namespace GetDateTimeInSpecificTimeZone
{
    namespace UiPath.Shared.Activities.Utilities
    {
        public class EnumNameConverter<T> : EnumConverter
        {
            public EnumNameConverter() : base(typeof(T))
            {

            }

            public EnumNameConverter(Type type) : base(type)
            {
            }

            public override bool CanConvertTo(ITypeDescriptorContext context, Type destType)
            {
                return destType == typeof(string);
            }

            public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destType)
            {
                FieldInfo fieldInfo = EnumType.GetField(Enum.GetName(EnumType, value));
                DescriptionAttribute description = (DescriptionAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute));

                return description != null ? description.Description : value.ToString();
            }

            public override bool CanConvertFrom(ITypeDescriptorContext context, Type srcType)
            {
                return srcType == typeof(string);
            }

            public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
            {
                foreach (FieldInfo fieldInfo in EnumType.GetFields())
                {
                    DescriptionAttribute description = (DescriptionAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute));

                    if (description != null && (string)value == description.Description)
                        return Enum.Parse(EnumType, fieldInfo.Name);
                }

                return Enum.Parse(EnumType, (string)value);
            }
        }
    }

    public enum Timezones
    {
        [Description("(GMT-12:00) International Date Line West")]
        Dateline_Standard_Time,

        [Description("(GMT-11:00) Midway Island, Samoa")]
        Samoa_Standard_Time,

        [Description("(GMT-10:00) Hawaii")]
        Hawaiian_Standard_Time,

        [Description("(GMT-09:00) Alaska")]
        Alaskan_Standard_Time,

        [Description("(GMT-08:00) Pacific Time (US and Canada); Tijuana")]
        Pacific_Standard_Time,

        [Description("(GMT-07:00) Mountain Time (US and Canada)")]
        Mountain_Standard_Time,

        [Description("(GMT-07:00) Arizona")]
        US_Mountain_Standard_Time,

        [Description("(GMT-06:00) Central Time (US and Canada)")]
        Central_Standard_Time,

        [Description("(GMT-06:00) Saskatchewan")]
        Canada_Central_Standard_Time,

        [Description("(GMT-06:00) Central America")]
        Central_America_Standard_Time,

        [Description("(GMT-05:00) Eastern Time (US and Canada)")]
        Eastern_Standard_Time,

        [Description("(GMT-05:00) Indiana (East)")]
        US_Eastern_Standard_Time,

        [Description("(GMT-05:00) Bogota, Lima, Quito")]
        SA_Pacific_Standard_Time,

        [Description("(GMT-04:00) Atlantic Time (Canada)")]
        Atlantic_Standard_Time,

        [Description("(GMT-04:00) Georgetown, La Paz, San Juan")]
        SA_Western_Standard_Time,

        [Description("(GMT-04:00) Santiago")]
        Pacific_SA_Standard_Time,

        [Description("(GMT-03:30) Newfoundland")]
        Newfoundland_and_Labrador_Standard_Time,

        [Description("(GMT-03:00) Brasilia")]
        EDOT_South_America_Standard_Time,

        [Description("(GMT-03:00) Georgetown")]
        SA_Eastern_Standard_Time,

        [Description("GMT-03:00) Greenland")]
        Greenland_Standard_Time,

        [Description("(GMT-02:00) Mid-Atlantic")]
        MidHYPHENAtlantic_Standard_Time,

        [Description("(GMT-01:00) Azores")]
        Azores_Standard_Time,

        [Description("(GMT-01:00) Cape Verde Islands")]
        Cape_Verde_Standard_Time,

        [Description("(GMT) Greenwich Mean Time: Dublin, Edinburgh, Lisbon, London")]
        GMT_Standard_Time,

        [Description("(GMT) Monrovia, Reykjavik")]
        Greenwich_Standard_Time,

        [Description("(GMT+01:00) Belgrade, Bratislava, Budapest, Ljubljana, Prague")]
        Central_Europe_Standard_Time,

        [Description("(GMT+01:00) Sarajevo, Skopje, Warsaw, Zagreb")]
        Central_European_Standard_Time,

        [Description("(GMT+01:00) Brussels, Copenhagen, Madrid, Paris")]
        Romance_Standard_Time,

        [Description("(GMT+01:00) Amsterdam, Berlin, Bern, Rome, Stockholm, Vienna")]
        WDOT_Europe_Standard_Time,

        [Description("(GMT+01:00) West Central Africa")]
        WDOT_Central_Africa_Standard_Time,

        [Description("(GMT+02:00) Minsk")]
        EDOT_Europe_Standard_Time,

        [Description("(GMT+02:00) Cairo")]
        Egypt_Standard_Time,

        [Description("(GMT+02:00) Helsinki, Kiev, Riga, Sofia, Tallinn, Vilnius")]
        FLE_Standard_Time,

        [Description("(GMT+02:00) Athens, Bucharest, Istanbul")]
        GTB_Standard_Time,

        [Description("(GMT+02:00) Jerusalem")]
        Israel_Standard_Time,

        [Description("(GMT+02:00) Harare, Pretoria")]
        South_Africa_Standard_Time,

        [Description("(GMT+03:00) Moscow, St. Petersburg, Volgograd")]
        Russian_Standard_Time,

        [Description("(GMT+03:00) Kuwait, Riyadh")]
        Arab_Standard_Time,

        [Description("(GMT+03:00) Nairobi")]
        EDOT_Africa_Standard_Time,

        [Description("(GMT+03:00) Baghdad")]
        Arabic_Standard_Time,

        [Description("(GMT+03:30) Tehran")]
        Iran_Standard_Time,

        [Description("(GMT+04:00) Abu Dhabi, Muscat")]
        Arabian_Standard_Time,

        [Description("(GMT+04:00) Baku, Tbilisi, Yerevan")]
        Caucasus_Standard_Time,

        [Description("(GMT+04:30) Kabul")]
        Afghanistan_Standard_Time,

        [Description("(GMT+05:00) Ekaterinburg")]
        Ekaterinburg_Standard_Time,

        [Description("(GMT+05:00) Tashkent")]
        West_Asia_Standard_Time,

        [Description("(GMT+05:30) Chennai, Kolkata, Mumbai, New Delhi")]
        India_Standard_Time,

        [Description("(GMT+05:45) Kathmandu")]
        Nepal_Standard_Time,

        [Description("(GMT+06:00) Astana, Dhaka")]
        Central_Asia_Standard_Time,

        [Description("(GMT+06:00) Sri Jayawardenepura")]
        Sri_Lanka_Standard_Time,

        [Description("(GMT+06:00) Almaty, Novosibirsk")]
        NDOT_Central_Asia_Standard_Time,

        [Description("(GMT+06:30) Yangon (Rangoon)")]
        Myanmar_Standard_Time,

        [Description("(GMT+07:00) Bangkok, Hanoi, Jakarta")]
        SE_Asia_Standard_Time,

        [Description("(GMT+07:00) Krasnoyarsk")]
        North_Asia_Standard_Time,

        [Description("(GMT+08:00) Beijing, Chongqing, Hong Kong, Urumqi")]
        China_Standard_Time,

        [Description("(GMT+08:00) Kuala Lumpur, Singapore")]
        Singapore_Standard_Time,

        [Description("(GMT+08:00) Taipei")]
        Taipei_Standard_Time,

        [Description("(GMT+08:00) Perth")]
        WDOT_Australia_Standard_Time,

        [Description("(GMT+08:00) Irkutsk, Ulaanbaatar")]
        North_Asia_East_Standard_Time,

        [Description("(GMT+09:00) Seoul")]
        Korea_Standard_Time,

        [Description("(GMT+09:00) Osaka, Sapporo, Tokyo")]
        Tokyo_Standard_Time,

        [Description("(GMT+09:00) Yakutsk")]
        Yakutsk_Standard_Time,

        [Description("(GMT+09:30) Darwin")]
        AUS_Central_Standard_Time,

        [Description("(GMT+09:30) Adelaide")]
        CenDOT_Australia_Standard_Time,

        [Description("(GMT+10:00) Canberra, Melbourne, Sydney")]
        AUS_Eastern_Standard_Time,

        [Description("(GMT+10:00) Brisbane")]
        EDT_Australia_Standard_Time,

        [Description("(GMT+10:00) Hobart")]
        Tasmania_Standard_Time,

        [Description("(GMT+10:00) Vladivostok")]
        Vladivostok_Standard_Time,

        [Description("(GMT+10:00) Guam, Port Moresby")]
        West_Pacific_Standard_Time,

        [Description("(GMT+11:00) Magadan, Solomon Islands, New Caledonia")]
        Central_Pacific_Standard_Time,

        [Description("(GMT+12:00) Fiji, Kamchatka, Marshall Is.")]
        Fiji_Standard_Time,

        [Description("(GMT+12:00) Auckland, Wellington")]
        New_Zealand_Standard_Time,

        [Description("(GMT+13:00) Nuku'alofa")]
        Tonga_Standard_Time,

        [Description("(GMT-03:00) Buenos Aires")]
        Azerbaijan_Standard_Time,

        [Description("(GMT+02:00) Beirut")]
        Middle_East_Standard_Time,

        [Description("(GMT+02:00) Amman")]
        Jordan_Standard_Time,

        [Description("(GMT+02:00) Windhoek")]
        Namibia_Standard_Time,

        [Description("(GMT+03:00) Tbilisi")]
        Georgian_Standard_Time,

        [Description("(GMT-04:00) Manaus")]
        Central_Brazilian_Standard_Time,

        [Description("(GMT-03:00) Montevideo")]
        Montevideo_Standard_Time,

        [Description("(GMT-04:30) Caracas")]
        Venezuela_Standard_Time,

        [Description("(GMT-03:00) Buenos Aires")]
        Argentina_Standard_Time,

        [Description("(GMT) Casablanca")]
        Morocco_Standard_Time,

        [Description("(GMT+05:00) Islamabad, Karachi")]
        Pakistan_Standard_Time,

        [Description("(GMT+04:00) Port Louis")]
        Mauritius_Standard_Time,

        [Description("(GMT) Coordinated Universal Time")]
        UTC,

        [Description("(GMT-04:00) Asuncion")]
        Paraguay_Standard_Time,

        [Description("(GMT+12:00) Petropavlovsk-Kamchatsky")]
        Kamchatka_Standard_Time

    }
    
    public class GetDateTimeInTimeZone:CodeActivity
    {

        [Category("Input")]
        [RequiredArgument]
        [DisplayName("Input <DateTime>")]
        [Description("By Default: DateTime.Now")]
        public InArgument<DateTime> InputDateTime { get; set; } = DateTime.Now;

        [Category("Input")]
        [RequiredArgument]
        [DisplayName("Input / From Timezone")]
        [Description("By Default: India Standard Time")]
        [TypeConverter(typeof(EnumNameConverter<Timezones>))]
        public Timezones InputOrFromTimeZoneId { get; set; } = Timezones.India_Standard_Time;

        [Category("Input")]
        [RequiredArgument]
        [DisplayName("Output / To Timezone")]
        [Description("By Default: Pacific Standard Time")]
        [TypeConverter(typeof(EnumNameConverter<Timezones>))]
        public Timezones OutputOrToTimeZoneId { get; set; } = Timezones.Pacific_Standard_Time;

        [Category("Ouput")]
        [RequiredArgument]
        [DisplayName("Output <DateTime>")]
        public OutArgument<DateTime> OutputDateTime { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            DateTime input = InputDateTime.Get(context);
            string inTimezone = InputOrFromTimeZoneId.ToString().Replace('_',' ').Replace("DOT", ".").Replace("HYPHEN", "-");
            string outTimezone = OutputOrToTimeZoneId.ToString().Replace('_', ' ').Replace("DOT", ".").Replace("HYPHEN", "-");
            TimeZoneInfo InputTimezone = TimeZoneInfo.FindSystemTimeZoneById(inTimezone);
            TimeZoneInfo OutputTimezone = TimeZoneInfo.FindSystemTimeZoneById(outTimezone);


            TimeSpan inputTimeSpan = InputTimezone.BaseUtcOffset;
            Console.WriteLine(inputTimeSpan.TotalHours);
            Console.WriteLine(input.Add(-inputTimeSpan).ToShortTimeString() +" UTC"); // To UTC
            DateTime utc = input.Add(-inputTimeSpan);

            TimeSpan outputTimeSpan = OutputTimezone.BaseUtcOffset;
            Console.WriteLine(outputTimeSpan.TotalHours);
            Console.WriteLine(utc.Add(outputTimeSpan).ToShortTimeString() + " " + outTimezone); //From UTC to OutputTimezone

            OutputDateTime.Set(context, (utc.Add(outputTimeSpan)));


        }
    }
}
