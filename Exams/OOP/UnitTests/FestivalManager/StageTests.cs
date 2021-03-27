// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    //using FestivalManager.Entities;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
	public class StageTests
    {
		private Stage stage;
		private Performer performerNull;
		private Performer performerTooYoung;
		private Performer validPerformer;
		private Song songNull;
		private Song validSong;

		[SetUp]
		public void Init()
        {
			this.stage = new Stage();
			this.performerNull = null;
			this.performerTooYoung = new Performer("T", "T", 15);
			this.validPerformer = new Performer("Test", "Testov", 20);
			this.songNull = null;
			this.validSong= new Song("Test", TimeSpan.FromSeconds(155));

		}						

		[Test]
	    public void CtorTestIfNotNull()
	    {			
			Assert.IsNotNull(stage);
		}
		[Test]
		public void IReadOnlyPerformersIsNotNull()
        {
			Assert.IsNotNull(stage.Performers);			
        }
		[Test]
		public void AddPerformerWithNullPerformerException()
        {						
			Assert.That(() => stage.AddPerformer(performerNull), Throws.ArgumentNullException);
        }
		[Test]
		public void AddPerformerWithAgeLessThan18()
        {			
			Assert.That(() => stage.AddPerformer(performerTooYoung), Throws.ArgumentException);
		}
		[Test]
		public void AddingValidPerfomer()
        {					
			stage.AddPerformer(validPerformer);
			Assert.AreEqual(1, stage.Performers.Count);
		}
		[Test]
		public void AddSongWithNull()
        {					
			Assert.That(() => stage.AddSong(songNull), Throws.ArgumentNullException);
		}
		[Test]
		public void AddSongWithLowDuration()
		{			
			Song song = new Song("Test", TimeSpan.FromSeconds(5));
			Assert.That(() => stage.AddSong(song), Throws.ArgumentException);
		}
		
		[Test]
		public void AddSongToPerformerNullPerformer()
        {					
			Assert.That(() => stage.AddSongToPerformer(validSong.Name, null), Throws.ArgumentNullException);
		}
		[Test]
		public void AddSongToPerformerNullSong()
		{						
			Assert.That(() => stage.AddSongToPerformer(null, validPerformer.FullName), Throws.ArgumentNullException);
		}
		[Test]
		public void AddSongToPerformerValid()
        {									
			stage.AddPerformer(validPerformer);
			stage.AddSong(validSong);			
			Assert.AreEqual($"{validSong} will be performed by {validPerformer.FullName}", 
				stage.AddSongToPerformer("Test", validPerformer.FullName));
		}
		[Test]
		public void PlayStringResult()
        {						
			stage.AddPerformer(validPerformer);
			stage.AddSong(validSong);			
			stage.AddSongToPerformer(validSong.Name, validPerformer.FullName);			
			Assert.AreEqual("1 performers played 1 songs", stage.Play());
		}


	}
}