﻿namespace SkillNet.Domain.Organizations.Models
{
    public class ModelConstants
    {
        public class Common
        {
            public const int MaxUrlLength = 2048;
            public const int Zero = 0;
        }
        public class PhoneNumber
        {
            public const int MinPhoneNumberLength = 5;
            public const int MaxPhoneNumberLength = 20;
            public const string PhoneNumberRegularExpression = @"^\+[0-9]+$";
        }

        public class Pronouns
        {
            public const int MinPronounsLength = 5;
            public const int MaxPronounsLength = 21;
            public const string PronounsRegularExpression = @"^[a-zA-Z]+/[a-zA-Z]+$";
        }

        public class Organizer
        {
            public const int MinNameLength = 2;
            public const int MaxNameLength = 50;

            public const int MinBioLength = 0;
            public const int MaxBioLength = 300;

            public static readonly DateTime MinBirthDate = new DateTime(1900, 1, 1);
            public static readonly DateTime MaxBirthDate = DateTime.Now.AddYears(-18);
        }
        public class Employee
        {
            public const int MinNameLength = 2;
            public const int MaxNameLength = 50;

            public const int MinBioLength = 0;
            public const int MaxBioLength = 300;

            public static readonly DateTime MinBirthDate = new DateTime(1900, 1, 1);
            public static readonly DateTime MaxBirthDate = DateTime.Now.AddYears(-13);
        }
        public class Organization
        {
            public const int MinNameLength = 2;
            public const int MaxNameLength = 50;

            public const int MinDescriptionLength = 0;
            public const int MaxDescriptionLength = 500;

            public const double MinMonthlyFee = 0.0;
        }
        public class Member
        {
            public const int MinNameLength = 2;
            public const int MaxNameLength = 50;

            public const int MinBioLength = 0;
            public const int MaxBioLength = 300;

            public static readonly DateTime MinBirthDate = new DateTime(1900, 1, 1);
            public static readonly DateTime MaxBirthDate = DateTime.Now.AddYears(-13);
        }
        public class Group
        {
            public const int MinNameLength = 2;
            public const int MaxNameLength = 50;

            public const int MinDescriptionLength = 0;
            public const int MaxDescriptionLength = 300;
        }
    }
}
