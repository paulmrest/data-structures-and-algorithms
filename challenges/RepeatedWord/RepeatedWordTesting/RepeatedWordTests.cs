using System;
using Xunit;

namespace RepeatedWordTesting
{
    public class RepeatedWordTests
    {
        [Theory]
        [InlineData("a", "Once upon a time, there was a brave princess who...")]
        [InlineData("it", "It was the best of times, it was the worst of times, it was the age of wisdom, it was the age of foolishness, it was the epoch of belief, it was the epoch of incredulity, it was the season of Light, it was the season of Darkness, it was the spring of hope, it was the winter of despair, we had everything before us, we had nothing before us, we were all going direct to Heaven, we were all going direct the other way – in short, the period was so far like the present period, that some of its noisiest authorities insisted on its being received, for good or for evil, in the superlative degree of comparison only...")]
        [InlineData("summer", "It was a queer, sultry summer, the summer they electrocuted the Rosenbergs, and I didn’t know what I was doing in New York...")]
        [InlineData("consectetur", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Id consectetur purus ut faucibus pulvinar elementum. Ac tincidunt vitae semper quis lectus nulla at. Congue nisi vitae suscipit tellus mauris a. Maecenas volutpat blandit aliquam etiam. Est ultricies integer quis auctor. Eget magna fermentum iaculis eu non diam. Eget velit aliquet sagittis id consectetur. Diam volutpat commodo sed egestas egestas fringilla. Scelerisque purus semper eget duis at. Morbi quis commodo odio aenean sed adipiscing diam donec. Elementum tempus egestas sed sed. Quis imperdiet massa tincidunt nunc pulvinar sapien et ligula. Lectus magna fringilla urna porttitor rhoncus dolor. Odio ut enim blandit volutpat maecenas volutpat blandit aliquam etiam. Enim nunc faucibus a pellentesque sit. Volutpat diam ut venenatis tellus in metus vulputate. Pharetra et ultrices neque ornare.")]
        [InlineData("", "")]
        [InlineData("", "989vnw98tndgvfio81t82ng82hgklasg8lkdbiojhwrg235")]
        public void CanFindRepeatedWords(string expected, string testInput)
        {
            //Act
            string output = RepeatedWord.RepeatedWord.FindRepeatedWord(testInput);

            //Assert
            Assert.Equal(expected, output);
        }
    }
}
