using System;
using System.Text;
using Xunit;

namespace sunamo.Tests
{
    public class SHUnsafeTests
{
    [Fact]
    public void ReplaceUnsafeUnmanagedTest()
    {
            //            string testString = @"Assert.Equal -> Assert.AreEqual
            //Assert.AreEqual<*> -> CollectionAssert.AreEqual
            //[Fact] -> [TestMethod]
            //using Xunit; -> using Microsoft.VisualStudio.TestTools.UnitTesting;";
            //            testString = "Assert.AreEqual<*> -> CollectionAssert.AreEqual";

            //            string file = @"d:\Documents\Visual Studio 2017\Projects\sunamo.Tests\sunamo.Tests.Data\ReplaceManyFromString\In_ReplaceManyFromString.cs";
            //            var s = TF.ReadFile(file);

            //            s = SH.ReplaceManyFromString(s, testString, "->");

            //            TF.SaveFile(s, file);

            var inputS = @"void SetMode(object mode2)
{";

            var l = inputS.Length;

            var input = new StringBuilder( );
            input.Append(inputS);

            var inputS2 = input.ToString();

            string replaceWhat = @"void SetMode(object mode2)
{";

            var replaceFor = @"void SetMode(object mode2)
{
var mode = EnumHelper.Parse<Mode>(mode2.ToString(), Mode.Empty);";

            var excepted = @"void SetMode(object mode2)
{
var mode = EnumHelper.Parse<Mode>(mode2.ToString(), Mode.Empty);";


            var result = SHUnsafe.ReplaceUnsafeUnmanaged(input, replaceWhat, replaceFor);
            var result2 = result.ToString();
            

            Assert.Equal(excepted, result2);
        }
}
}
