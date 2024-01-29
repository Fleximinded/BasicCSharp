using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo.AnimalFarm.Animals
{
    public abstract class Animal
    {
        protected Animal(string name)
        {
            Name = name;
        }

        public string Name { get; set; } = "";
        public virtual string Species { get => GetType().Name; }
        public virtual void MakeSound() => Console.WriteLine(" - ");
        protected void Execute(string sound, string? species = null)
        {
            //??= Enkel als species null is wordt Species toegekend
            species ??= Species;
            Console.WriteLine($"I am a {species}, my name is {Name} and I make a {sound} sound");
            Play(species);
        }
        public static void Play(string fileNameSet)
        {
            try
            {
                string filePath = $@"e:\data\sounds\{fileNameSet}.wav";
                using(var audioFile = new AudioFileReader(filePath))
                using(var outputDevice = new WaveOutEvent())
                {
                    outputDevice.Init(audioFile);
                    outputDevice.Play();
                    while(outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        Thread.Sleep(1000);
                    }
                }
            } catch(Exception ex)
            {
                Console.WriteLine($"There was an error: {ex.ToString()}");
            }
        }
    }
}
