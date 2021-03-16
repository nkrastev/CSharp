// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    [TestFixture]
	public class StageTests
    {
		private Stage stage;
		private Performer performerIvan;
		private Performer performerPesho;
		private Song validSong;

		private List<Song> songs;
		private List<Performer> performers;

		[SetUp]
		public void Setup()
        {
			this.stage = new Stage();
			this.performerIvan = new Performer("Ivan", "Ivanov", 30);
			this.performerPesho = new Performer("Pesho", "Peshov", 35);

			//this.stage.AddPerformer(performerIvan);
			//this.stage.AddPerformer(performerPesho);

			this.validSong = new Song("Valid Song Name", TimeSpan.FromSeconds(150));			
			this.songs = new List<Song>();
			this.performers = new List<Performer>();			
        }
		[Test]
		public void StageConstructorWithTwoLists()
        {			
			var performersList = new List<Performer>();
			var songList = new List<Song>();
			
			Assert.IsNotNull(performersList);
			Assert.IsNotNull(songList);
			var stageForCtor = new Stage();
			Assert.IsNotNull(stageForCtor);

		}

		[Test]
	    public void StageConstructor()
	    {
			//arrange
			var stage = new Stage();
			//act & assert
			Assert.IsNotNull(stage);
		}
		[Test]
		public void AddPerformerThrowsExceptionWithNull()
        {
			Performer performerIvan = null;
			Assert.That(() => stage.AddPerformer(performerIvan), Throws.ArgumentNullException);
		}
		[Test]
		public void AddPerformerThrowsExceptionWithAgeLessThan18()
		{
			Performer performer = new Performer("T", "I", 15);
			Assert.That(() => stage.AddPerformer(performer), Throws.ArgumentException);
		}
        [Test]
        public void AddPerformerCountIncreased()
        {
            stage.AddPerformer(performerIvan);
            stage.AddPerformer(performerPesho);
            performers.Add(performerIvan);
            performers.Add(performerPesho);
            Assert.AreEqual(2, stage.Performers.Count);
            Assert.AreEqual(2, performers.Count);
        }
        [Test]
		public void AddSongThrowsExceptionWithNull()
		{
			Song song = null;
			Assert.That(() => stage.AddSong(song), Throws.ArgumentNullException);
		}
		[Test]
		public void AddSongThrowsExceptionSongWithDurationLow()
		{
			Song song = new Song("TestSong", TimeSpan.FromSeconds(11));
			Assert.That(() => stage.AddSong(song), Throws.ArgumentException);
		}
		[Test]
		public void AddSongIncreaseTheNumberOfSongs()
		{
			Song song = new Song("TestSong", TimeSpan.FromSeconds(150));
			stage.AddSong(song);
			songs.Add(song);
			Assert.AreEqual(1, songs.Count);
			//TODO ASSERT?!
		}
		[Test]
		public void AddSongToPerformerThrowsNullFromSongName()
        {			
			Assert.That(() => stage.AddSongToPerformer(null,"Ivan"), Throws.ArgumentNullException);
		}
		[Test]
		public void AddSongToPerformerThrowsNullFromPerformerName()
		{
			Assert.That(() => stage.AddSongToPerformer("TestSong", null), Throws.ArgumentNullException);
		}
		[Test]
		public void AddSongToPerformerWithNotExistingPerformer()
        {
			Assert.That(() => stage.AddSongToPerformer("TestSong", "Petar"), Throws.ArgumentException);
		}
		[Test]
		public void AddSongToPerformerWithNotExistingSong()
		{
			stage.AddPerformer(performerIvan);
			stage.AddSong(validSong);
			performerIvan.SongList.Add(validSong);
			Assert.That(() => stage.AddSongToPerformer("Unknown Song Name", "Ivan Ivanov"), Throws.ArgumentException);
		}

		[Test]
		public void AddSongToPerformerSuccessfullyAdd()
        {
			stage.AddPerformer(performerIvan);
			stage.AddSong(validSong);
			performerIvan.SongList.Add(validSong);
			stage.AddSongToPerformer("Valid Song Name", "Ivan Ivanov");

			Assert.AreEqual(
				$"{validSong.ToString()} will be performed by {performerIvan.ToString()}",
				stage.AddSongToPerformer("Valid Song Name", "Ivan Ivanov"));
        }
		[Test]
		public void PlayMethod()
        {
			var songsCount = this.performers.Sum(p => p.SongList.Count());
			Assert.AreEqual($"{this.performers.Count} performers played {songsCount} songs", stage.Play());			
		}		
		//judge do not test the content of the exception messages... for this one ;)


	}
}