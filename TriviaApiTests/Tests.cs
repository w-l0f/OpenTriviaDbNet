using System.Threading.Tasks;
using NUnit.Framework;
using OpenTriviaDbNet;
using OpenTriviaDbNet.Models;

namespace TriviaApiTests
{
    public class Tests
    {
        private OpenTriviaDatabaseApi api;
        
        [SetUp]
        public void Setup()
        {
            api = new OpenTriviaDatabaseApi();
        }

        [Test]
        public async Task GetCategories()
        {
            var categories = await this.api.GetCategories();
            Assert.That(categories.Length, Is.Not.Zero);
        }
        
        [Test]
        public async Task GetQuestion()
        {
            var questions = await this.api.GetQuestions(1, null, null, null);
            Assert.That(questions.Length, Is.EqualTo(1));
        }

        [Test]
        public async Task GetQuestionsWithFilter()
        {
            var questions = await this.api.GetQuestions(5, null, Enums.QuestionType.MultiChoice, Enums.Difficulty.Easy);
            Assert.That(questions.Length, Is.EqualTo(5));
        }
        
        [Test]
        public async Task GetResetSessionToken()
        {
            await this.api.CreateSessionToken();
            var originalToken = this.api.SessionToken;
            await this.api.CreateSessionToken();
            Assert.That(this.api.SessionToken, Is.Not.EqualTo(originalToken));

            await this.api.ResetSessionToken();
        }
    }
}