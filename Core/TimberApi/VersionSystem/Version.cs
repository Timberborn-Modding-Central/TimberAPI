using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TimberApi.VersionSystem
{
    public class Version : IComparable<Version>, IComparable
    {
        private static readonly Regex _versionRegex = new(@"^
            ([0-9]+)                                    # Major
            \.
            ([0-9]+)                                    # Minor
            \.
            ([0-9]+)                                    # Patch
            [\.]?                                       # Optional revision dot
            ([0-9]+)?                                   # Revision (optional)
            (?:-([0-9A-Za-z-]+(?:\.[0-9A-Za-z-]+)*))?   # Pre-release
            $", RegexOptions.IgnorePatternWhitespace);

        private readonly int _major;

        private readonly int _minor;

        private readonly int _patch;

        private readonly string _preRelease;

        private readonly int _revision;

        public Version(int major, int minor, int patch, int revision = 0, string preRelease = "")
        {
            _major = major;
            _minor = minor;
            _patch = patch;
            _revision = revision;
            _preRelease = preRelease;
        }

        public bool IsPreRelease => !string.IsNullOrEmpty(_preRelease);

        public int CompareTo(object? obj)
        {
            return obj == null ? 1 : CompareTo(obj as Version ?? throw new ArgumentException("Object is not a Version"));
        }

        public int CompareTo(Version? other)
        {
            if (other == null)
            {
                return 1;
            }

            foreach (int compareResult in CompareVersions(other))
            {
                if (compareResult != 0)
                {
                    return compareResult;
                }
            }

            return 0;
        }

        public static Version Parse(string version)
        {
            bool isMatch = _versionRegex.IsMatch(version);
            if (!isMatch)
            {
                throw new Exception("version string does not match regex");
            }

            Match regexMatch = _versionRegex.Match(version);

            return new Version(int.Parse(regexMatch.Groups[1].Value), int.Parse(regexMatch.Groups[2].Value), int.Parse(regexMatch.Groups[3].Value),
                regexMatch.Groups[4].Success ? int.Parse(regexMatch.Groups[4].Value) : 0, regexMatch.Groups[5].Value);
        }

        public IEnumerable<int> CompareVersions(Version other)
        {
            yield return _major.CompareTo(other._major);
            yield return _minor.CompareTo(other._minor);
            yield return _patch.CompareTo(other._patch);
            yield return _revision.CompareTo(other._revision);
        }

        public override string ToString()
        {
            return $"{_major}.{_minor}.{_patch}.{_revision}{(IsPreRelease ? "-" + _preRelease : "")}";
        }

        public static bool operator >=(Version operand1, Version operand2)
        {
            return operand1.CompareTo(operand2) >= 0;
        }

        public static bool operator <=(Version operand1, Version operand2)
        {
            return operand1.CompareTo(operand2) <= 0;
        }

        public static bool operator >(Version operand1, Version operand2)
        {
            return operand1.CompareTo(operand2) > 0;
        }

        public static bool operator <(Version operand1, Version operand2)
        {
            return operand1.CompareTo(operand2) < 0;
        }
    }
}