﻿/*
LargeXlsx - Minimalistic .net library to write large XLSX files

Copyright 2020 Salvatore ISAJA. All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:

1. Redistributions of source code must retain the above copyright notice,
this list of conditions and the following disclaimer.

2. Redistributions in binary form must reproduce the above copyright notice,
this list of conditions and the following disclaimer in the documentation
and/or other materials provided with the distribution.

THIS SOFTWARE IS PROVIDED THE COPYRIGHT HOLDER ``AS IS'' AND ANY EXPRESS
OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES
OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN
NO EVENT SHALL THE COPYRIGHT HOLDER BE LIABLE FOR ANY DIRECT,
INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
(INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/
using FluentAssertions;
using NUnit.Framework;

namespace LargeXlsx.Tests
{
    [TestFixture]
    public static class UtilTest
    {
        [Test]
        public static void EscapeXmlText()
        {
            var escapedXmlText = Util.EscapeXmlText("Lorem 'ipsum' & \"dolor\" <sit> amet");
            escapedXmlText.Should().Be("Lorem 'ipsum' &amp; \"dolor\" &lt;sit&gt; amet");
        }

        [Test]
        public static void EscapeXmlAttribute()
        {
            var escapedXmlText = Util.EscapeXmlAttribute("Lorem 'ipsum' & \"dolor\" <sit> amet");
            escapedXmlText.Should().Be("Lorem &apos;ipsum&apos; &amp; &quot;dolor&quot; &lt;sit&gt; amet");
        }

        [TestCase(1, "A")]
        [TestCase(2, "B")]
        [TestCase(26, "Z")]
        [TestCase(27, "AA")]
        [TestCase(28, "AB")]
        [TestCase(52, "AZ")]
        [TestCase(53, "BA")]
        [TestCase(702, "ZZ")]
        [TestCase(703, "AAA")]
        [TestCase(704, "AAB")]
        [TestCase(729, "ABA")]
        [TestCase(1378, "AZZ")]
        [TestCase(1379, "BAA")]
        [TestCase(16384, "XFD")]
        public static void GetColumnName(int index, string expectedName)
        {
            var name = Util.GetColumnName(index);
            name.Should().Be(expectedName);
        }
    }
}