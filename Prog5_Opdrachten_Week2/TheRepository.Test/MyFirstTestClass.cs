using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheRepository.ViewModel;
using Moq;
using System.Collections.Generic;

namespace TheRepository.Test
{
    [TestClass]
    public class MyFirstTestClass
    {
        [TestMethod]
        public void MyFirstTestMethode()
        {
            //1. Arrange
         
            //2. Act

            //3. Assert

        }
        [TestMethod]
        public void LeaseMaandKosten_Correct_Test() {
          //1. Arrange
          CarVM auto = new CarVM(new Car() );
          auto.Prijs = 1000;
          auto.Bijtelling = 50;

          //2. Act

          double result = auto.LeaseKostenPerMaand;

          //3. Assert
          Assert.AreEqual(40, result);

        }

        [TestMethod]
        public void LeaseJaarKosten_Correct_Test() {
          //1. Arrange
          CarVM auto = new CarVM(new Car() );
          auto.Prijs = 1000;
          auto.Bijtelling = 50;

          //2. Act
          double result = auto.LeaseKostenPerJaar;

          //3. Assert
          Assert.AreEqual(480, result);

        }

        [TestMethod]
        public void MainViewModel_MOQ_Success() {

          //Arrange
          // zet een Mock klaar voor de lijst met autos
          Mock<ICarRepository> moq = new Mock<ICarRepository>();

          // vul de mock met de autos
          // de methode GetAllCars werkt vanwege de Interface
          moq.Setup(m => m.GetAllCars())
              .Returns(new List<Car>()
                {
                    new Car{ Actief = true,  Bijtelling = 100, Prijs =  5000,},
                    new Car{ Actief = false, Bijtelling = 200, Prijs = 10000,},
                    new Car{ Actief = true,  Bijtelling = 300, Prijs = 15000,},
                    new Car{ Actief = false, Bijtelling = 400, Prijs = 20000,}
                });

          // gebruik deze Mock lijst om het MainViewModel te testen
          var mainVM = new MainViewModel(moq.Object);


          //Act
          // MainViewModel gaat de totale prijs uitrekenen 
          var result = mainVM.TotalePrijs;

          //Assert
          Assert.AreEqual(20000, result);

        }
    }

}
