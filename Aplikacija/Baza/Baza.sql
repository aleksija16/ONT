-- MySQL dump 10.13  Distrib 8.0.20, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: organizacija
-- ------------------------------------------------------
-- Server version	5.7.17-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `anketa`
--

DROP TABLE IF EXISTS `anketa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `anketa` (
  `IdAnkete` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `IdTuristeAnk` int(10) unsigned NOT NULL,
  `IdTureAnk` int(10) unsigned DEFAULT NULL,
  `IdVodicaAnk` int(10) unsigned DEFAULT NULL,
  `KonacnaOcena` int(10) unsigned DEFAULT NULL,
  `Komentar` varchar(1000) DEFAULT NULL,
  `OrganizovanostTure` int(10) unsigned DEFAULT NULL,
  `InformisanostVodica` int(10) unsigned DEFAULT NULL,
  `FizickaZahtevnostTure` int(10) unsigned DEFAULT NULL,
  `TipTuriste` varchar(45) DEFAULT NULL,
  `NajinteresantnijaZnamenitost` varchar(45) DEFAULT NULL,
  `NajdosadnijaZnamenitost` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`IdAnkete`),
  KEY `IdTuristeAnk_idx` (`IdTuristeAnk`),
  KEY `IdTureAnk_idx` (`IdTureAnk`),
  KEY `IdVodicaAnk_idx` (`IdVodicaAnk`),
  CONSTRAINT `IdTureAnk` FOREIGN KEY (`IdTureAnk`) REFERENCES `ture` (`IdTure`) ON DELETE CASCADE,
  CONSTRAINT `IdTuristeAnk` FOREIGN KEY (`IdTuristeAnk`) REFERENCES `turisti` (`IdTuriste`),
  CONSTRAINT `IdVodicaAnk` FOREIGN KEY (`IdVodicaAnk`) REFERENCES `vodici` (`IdVodica`) ON DELETE SET NULL
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `anketa`
--

LOCK TABLES `anketa` WRITE;
/*!40000 ALTER TABLE `anketa` DISABLE KEYS */;
INSERT INTO `anketa` VALUES (21,4,NULL,2,3,'nemam',23,28,81,'PorodicniOdmor','Čegar','Bubanj'),(22,4,NULL,2,10,'ok',80,100,86,'PorodicniOdmor','Bubanj','Bubanj'),(23,4,NULL,2,0,NULL,50,50,50,'PorodicniOdmor','Bubanj','Bubanj'),(24,7,1,3,10,'Tura je bila odlicna',18,30,81,'Porodični odmor','Koncentracioni logor','Spomenik na Čegru'),(25,7,1,3,2,'Tura je bila dosadna',18,15,16,'Porodični odmor','Ćele Kula','Koncentracioni logor'),(26,9,3,2,10,'Deci se veoma dopala ova tura. Organizacija je bila odlicna kao i sam vodic.',100,100,96,'Porodični odmor','Ćele Kula','Arheološka sala'),(27,7,6,4,6,'Tura bi bila bolja da nije bilo kise, bila je zahtevna',81,92,38,'Porodični odmor','Ćele Kula','Spomenik Kralju Aleksandru'),(28,6,6,4,10,'Organizacija nije bila na nivou, ali je vodic popravio utisak o ovoj turi',84,100,90,'Porodični odmor','Ćele Kula','Spomenik Stevanu Sremcu i Kalči'),(29,6,12,2,8,NULL,93,98,91,'Porodični odmor','Memorijalni park Bubanj','Tvrđava'),(30,1,1,3,8,'Okej tura',74,86,6,'Porodični odmor','Ćele Kula','Spomenik oslobodiocima Niša');
/*!40000 ALTER TABLE `anketa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `halloffame`
--

DROP TABLE IF EXISTS `halloffame`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `halloffame` (
  `IdHallOfFame` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `IdTuristeHof` int(10) unsigned NOT NULL,
  `IdKvizaHof` int(10) unsigned NOT NULL,
  `Poeni` int(11) NOT NULL,
  `DatumRadjenja` date DEFAULT NULL,
  PRIMARY KEY (`IdHallOfFame`),
  KEY `IdKviza_idx` (`IdKvizaHof`) USING BTREE,
  KEY `IdTuristeHof_idx` (`IdTuristeHof`),
  CONSTRAINT `IdKvizaHof` FOREIGN KEY (`IdKvizaHof`) REFERENCES `kvizovi` (`IdKviza`),
  CONSTRAINT `IdTuristeHof` FOREIGN KEY (`IdTuristeHof`) REFERENCES `turisti` (`IdTuriste`)
) ENGINE=InnoDB AUTO_INCREMENT=57 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `halloffame`
--

LOCK TABLES `halloffame` WRITE;
/*!40000 ALTER TABLE `halloffame` DISABLE KEYS */;
INSERT INTO `halloffame` VALUES (21,4,2,50,'2020-06-20'),(22,4,4,33,'2020-06-18'),(23,4,5,66,'2020-06-21'),(24,4,3,33,'2020-04-19'),(25,4,9,16,'2020-05-19'),(26,2,2,50,'2020-05-05'),(27,2,4,33,'2020-06-11'),(28,2,8,42,'2020-04-12'),(29,2,1,75,'2020-06-15'),(30,3,2,75,'2020-03-13'),(31,3,8,57,'2020-06-01'),(32,3,10,50,'2020-05-10'),(33,3,6,100,'2020-06-28'),(34,8,2,25,'2020-03-03'),(35,8,4,44,'2020-04-09'),(36,8,1,75,'2020-06-19'),(37,8,6,50,'2020-06-30'),(38,8,10,100,'2020-04-14'),(39,6,2,50,'2020-05-18'),(40,6,8,71,'2020-06-04'),(41,6,5,33,'2020-06-03'),(42,6,9,66,'2020-05-02'),(43,7,2,75,'2020-04-20'),(44,1,4,55,'2020-05-30'),(45,1,3,66,'2020-06-28'),(46,5,2,50,'2020-06-27'),(47,5,4,55,'2020-06-30'),(48,5,1,50,'2020-06-20'),(49,5,6,75,'2020-05-01'),(50,5,8,71,'2020-04-12'),(51,11,4,44,'2020-05-17'),(52,11,5,33,'2020-06-24'),(53,11,9,16,'2020-03-21'),(54,15,5,33,'2020-05-22'),(55,15,9,33,'2020-06-08'),(56,15,6,25,'2020-06-23');
/*!40000 ALTER TABLE `halloffame` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `korisnici`
--

DROP TABLE IF EXISTS `korisnici`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `korisnici` (
  `IdKorisnika` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Username` varchar(45) NOT NULL,
  `Password` varchar(45) NOT NULL,
  `TipKorisnika` varchar(1) NOT NULL,
  `IdVodicaK` int(10) unsigned DEFAULT NULL,
  `IdTuristeK` int(10) unsigned DEFAULT NULL,
  PRIMARY KEY (`IdKorisnika`),
  UNIQUE KEY `Username_UNIQUE` (`Username`),
  UNIQUE KEY `IdVodicaK_UNIQUE` (`IdVodicaK`),
  UNIQUE KEY `IdTuristeK_UNIQUE` (`IdTuristeK`),
  CONSTRAINT `IdTuristeK` FOREIGN KEY (`IdTuristeK`) REFERENCES `turisti` (`IdTuriste`),
  CONSTRAINT `IdVodicaK` FOREIGN KEY (`IdVodicaK`) REFERENCES `vodici` (`IdVodica`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=39 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `korisnici`
--

LOCK TABLES `korisnici` WRITE;
/*!40000 ALTER TABLE `korisnici` DISABLE KEYS */;
INSERT INTO `korisnici` VALUES (1,'admin','admin','A',NULL,NULL),(2,'marijanaont','marijanaont','V',1,NULL),(3,'alek','alek','T',NULL,1),(4,'markoont','markoont','V',2,NULL),(5,'aleksandaront','aleksandaront','V',8,NULL),(6,'stefanont','stefanont','V',3,NULL),(7,'milicaont','milicaont','V',4,NULL),(8,'srdjanont','srdjanont','V',5,NULL),(17,'alisaont','alisaont','V',9,NULL),(18,'selenaont','selenaont','V',10,NULL),(19,'jelenam','jelenam','T',NULL,6),(20,'sara','sara','T',NULL,2),(21,'vanja','vanja','T',NULL,3),(22,'aleksa','aleksa','T',NULL,4),(23,'dusann','dusann','T',NULL,7),(24,'zoranp','zoranp','T',NULL,8),(26,'mirelas','mirelas','T',NULL,9),(27,'ivanp','ivanp','T',NULL,10),(28,'janaj','janaj','T',NULL,11),(29,'kristinak','kristinak','T',NULL,12),(30,'markod','markod','T',NULL,13),(31,'jovanf','jovanf','T',NULL,14),(32,'hristinak','hristinak','T',NULL,15),(33,'jelenami','jelenami','T',NULL,16),(34,'denisj','denisj','T',NULL,17),(35,'urosi','urosi','T',NULL,18),(36,'kostaj','kostaj','T',NULL,19),(37,'oliverm','oliverm','T',NULL,20),(38,'goranr','goranr','T',NULL,5);
/*!40000 ALTER TABLE `korisnici` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `kvizovi`
--

DROP TABLE IF EXISTS `kvizovi`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `kvizovi` (
  `IdKviza` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `NazivKviza` varchar(45) NOT NULL,
  `IdZnamenitostiK` int(10) unsigned DEFAULT NULL,
  `IdTureK` int(10) unsigned DEFAULT NULL,
  PRIMARY KEY (`IdKviza`),
  KEY `IdZnamenitosti_idx` (`IdZnamenitostiK`),
  KEY `IdTureK_idx` (`IdTureK`),
  CONSTRAINT `IdTureK` FOREIGN KEY (`IdTureK`) REFERENCES `ture` (`IdTure`) ON DELETE SET NULL,
  CONSTRAINT `IdZnamenitostiK` FOREIGN KEY (`IdZnamenitostiK`) REFERENCES `znamenitosti` (`IdZnamenitosti`) ON DELETE SET NULL
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `kvizovi`
--

LOCK TABLES `kvizovi` WRITE;
/*!40000 ALTER TABLE `kvizovi` DISABLE KEYS */;
INSERT INTO `kvizovi` VALUES (1,'Detalji i sitnice',NULL,NULL),(2,'Kviz uz turu za lep dan',NULL,NULL),(3,'Istorijske znamenitosti',NULL,NULL),(4,'Crkve i manastiri',NULL,11),(5,'Brzi kviz',NULL,12),(6,'Niš',NULL,NULL),(7,'Upoznaj Niš',NULL,9),(8,'Tvrđava',1,NULL),(9,'Kviz o Bubnju',3,NULL),(10,'Kamenički vis',22,NULL),(11,'Kviz o svemu',NULL,NULL),(12,'Na istoku',NULL,NULL),(13,'Opšta pitanja',NULL,NULL),(14,'Spomenici i muzeji',NULL,6),(15,'O okolini',NULL,10),(16,'Kviz o pećini',20,NULL);
/*!40000 ALTER TABLE `kvizovi` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ocenjivanjevodica`
--

DROP TABLE IF EXISTS `ocenjivanjevodica`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ocenjivanjevodica` (
  `IdOcenjivanja` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `IdVodicaO` int(10) unsigned DEFAULT NULL,
  `IdTuristeO` int(10) unsigned DEFAULT NULL,
  `IdTureO` int(10) unsigned DEFAULT NULL,
  `Ocena` int(11) NOT NULL,
  PRIMARY KEY (`IdOcenjivanja`),
  KEY `IdOcenjivanja_idx` (`IdOcenjivanja`),
  KEY `IdVodicaO_idx` (`IdVodicaO`),
  KEY `IdTuristeO_idx` (`IdTuristeO`),
  KEY `IdTureO_idx` (`IdTureO`),
  CONSTRAINT `IdTureO` FOREIGN KEY (`IdTureO`) REFERENCES `ture` (`IdTure`) ON DELETE SET NULL,
  CONSTRAINT `IdTuristeO` FOREIGN KEY (`IdTuristeO`) REFERENCES `turisti` (`IdTuriste`),
  CONSTRAINT `IdVodicaO` FOREIGN KEY (`IdVodicaO`) REFERENCES `vodici` (`IdVodica`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ocenjivanjevodica`
--

LOCK TABLES `ocenjivanjevodica` WRITE;
/*!40000 ALTER TABLE `ocenjivanjevodica` DISABLE KEYS */;
INSERT INTO `ocenjivanjevodica` VALUES (15,4,7,6,7),(16,2,9,3,10),(17,4,6,6,10),(18,2,6,12,8),(20,2,7,12,5),(21,9,8,4,8);
/*!40000 ALTER TABLE `ocenjivanjevodica` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pitanja`
--

DROP TABLE IF EXISTS `pitanja`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pitanja` (
  `IdPitanja` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `TekstPitanja` varchar(1000) NOT NULL,
  `OdgovorA` varchar(1000) NOT NULL,
  `OdgovorB` varchar(1000) NOT NULL,
  `OdgovorC` varchar(1000) NOT NULL,
  `TacanOdgovor` varchar(1000) NOT NULL,
  `IdKviza` int(10) unsigned DEFAULT NULL,
  PRIMARY KEY (`IdPitanja`),
  KEY `IdKviza_idx` (`IdKviza`),
  CONSTRAINT `IdKviza` FOREIGN KEY (`IdKviza`) REFERENCES `kvizovi` (`IdKviza`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=70 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pitanja`
--

LOCK TABLES `pitanja` WRITE;
/*!40000 ALTER TABLE `pitanja` DISABLE KEYS */;
INSERT INTO `pitanja` VALUES (1,'Kada je spomen-park Bubanj proglašen kulturnim dobrom?','To se još uvek nije desilo','2007','1979','1979',1),(2,'Šta se ne nalazi u spomen-parku?','Letnja pozornica','Tvrđava','Kupola od stakla i metala','Tvrđava',7),(3,'U kom veku je nastala?','17.','18.','16.','18.',8),(4,'Od koliko pesnica se sastoji spomenik na Bubnju?','5','2','3','3',7),(5,'Koje godine je sagrađena?','Između 1719. i 1723. godine','Između 1619. i 1623. godine','Između 1519. i 1523. godine','Između 1719. i 1723. godine',8),(6,'Koji spomenik se nalazi u Tvrđavi?','Spomenik Milanu Obrenoviću','Spomenik Aleksandru Ujedinitelju','Spomenik Mihajlu Obrenoviću','Spomenik Milanu Obrenoviću',8),(7,'Kada se desila bitka na Čegru?','1890','1809','1790','1809',3),(8,'Koliko lobanja se nalazi u Ćele kuli?','58','27','132','58',3),(9,'Gde se nalazi HAMAM (tursko kupatilo) u Tvrđavi?','Na ulazu','Na izlazu','Ne nalazi se','Na ulazu',8),(10,'Da li je Tvrđava bila osvojena prilikom nekog napada?','Jeste','Nije nijednom','Nije bila napadana','Nije nijednom',8),(11,'Od koliko pesnica se sastoji spomenik na Bubnju?','0','2','3','3',2),(12,'Ko je dao konačni izgled Tvrđave?','Srbi','Rimljani','Osmanlije','Osmanlije',8),(13,'Koliko pesnica postoji?','3','4','5','3',9),(14,'Šta je po prvi put u Srbiji uspostavljeno baš u Nišu?','Katolička župa','Pravoslavna crkva','Sinagoga','Katolička župa',4),(15,'Šta simbolizuju pesnice?','	vojnike','muskarca, ženu i dete','3 muskarca','muskarca, ženu i dete',9),(16,'U podnožju koje planine se nalazi Gabrovački manastir?','U podnožju Svrljiških planina','U podnožju planine Seličevica','U podnožju planine Gabrovac','U podnožju planine Seličevica',4),(17,'Koja manifestacija se svake godine održava u Bubnju?','Nišvil','Humanitarni koncert','Oktobarfest','Humanitarni koncert',1),(18,'Na kojoj strani kod Kameničkog visa se nalazi izvor Studeni kladenac?','Na severnoj strani.','Na istočnoj strani.','Ne postoji izvor u blizini Kameničkog visa.','Na severnoj strani.',2),(19,'Od koliko pesnica se sastoji spomenik na Bubnju?','1','3','4','3',5),(20,'Koja od narednih izjava je tačna?','Bitka na Čegru se desila kao posledica izgradnje Ćele kule.','Spomenik na Bubnju je nastao kao spomenik stradanju srpskih vojnika.','Ćele kula je izgrađena kao opomena Srbima.','Ćele kula je izgrađena kao opomena Srbima.',5),(21,'Šta se desilo na ovom mestu?','Streljani su Turci','Bitka sa Turcima','Masovno streljanja zarobljenika iz Koncentracionog logora u Nišu','Masovno streljanja zarobljenika iz Koncentracionog logora u Nišu',9),(22,'Koja od narednih izjava je tačna?','Sve pesnice imaju istu visinu.','Sve pesnice imaju različite visine.','Niko do sad nije izmerio visine pesnica na Bubnju.','Sve pesnice imaju različite visine.',9),(23,'Kamenički vis je:','izletište','spomenik','park','izletište',10),(24,'Gde se nalazi?','na ulazu u Niš','14 km od Niša','u samom centru','14 km od Niša',10),(25,'Na kojoj nadmorskoj visini se nalazi?','od 750 do 800m','od 1850 do 1900m','od 200 do 270m','od 750 do 800m',10),(26,'Gde je smešten?','Na ograncima Svrljiških planina','Na vrhu Suve planine','U samom centru grada','Na ograncima Svrljiških planina',10),(27,'Po čemu je dobio ime?','Po kamenju','Po selu Kamenica','Po planini Kamenica','Po selu Kamenica',10),(28,'Koji drugi događaj je povezan sa bitkom na Čegru?','Prvi svetski rat','Drugi srpski ustanak','Prvi srpski ustanak','Prvi srpski ustanak',3),(29,'Ko se sukobio u bici na Čegru?','Srpski narod i turska vojska','Srpska i austrougarska vojska','Turska i austrougarska vojska','Srpski narod i turska vojska',3),(30,'Ko se istakao u bici na Čegru?','Stevan Sinđelić','Karađorđe','Hajduk Veljko','Stevan Sinđelić',3),(31,'Koja godina se smatra godinom oslobođenja Niša od Turaka?','1878','1901','1889','1878',3),(32,'Kada se desilo drugo bekstvo iz logora?','U decembru 1942. godine','U julu 1944. godine','Početkom 1941. godine','U decembru 1942. godine',6),(33,'Kada je formiran koncentracioni logor?','1940.','1941.','1943.','1941.',6),(34,'Koji car je rođen u Nišu?','Car Julijan','Car Dušan','Car Konstantin Veliki','Car Konstantin Veliki',6),(35,'Pod kojim imenom Niš je ranije bio poznat?','Singidunum','Nishville','Naissus','Naissus',6),(36,'Šta je simbol tvrđave?','Nišville','Stambol kapija','Barutane','Stambol kapija',8),(37,'Šta se nalazi na reljefu nedaleko od spomenika?','Natpis sa spiskom Nišlija koji su doprineli uređenju memorijalnog parka Bubanj.','Spisak imena svih ljudi koji su stradali na brdu Bubanj.','Stihovi niškog pesnika.','Stihovi niškog pesnika.',9),(38,'Kada je podignut spomenik na Bubnju?','2004','1978','1963','1963',9),(39,'Šta se od navedenih znamenitosti nalazi najbliže Kameničkom visu?','Ćele kula','Spomenik na Čegru','Memorijalni park Bubanj','Spomenik na Čegru',10),(40,'Koja znamenitost je nastala kao posledica bitke na Čegru?','Kamenički vis','Memorijalni park Bubanj','Ćele kula','Ćele kula',2),(41,'Koji je bio poslednji herojski podvig vojvode Sinđelića?','Otišao je u bitku sam.','Uspeo je da uvede grupu Srba u tursko utvrđenje.','Pucao je u barutanu.','Pucao je u barutanu.',2),(42,'Ko je naredio da se sagradi Ćele kula?','srpski vojvoda','austrougarski car','turski paša','turski paša',1),(43,'Koji dokument je uručen u Banovini u Nišu?','Pismo predsedniku Republike Srbije','Pismo niškom gradolnačelniku','Telegram kojim je objavljen rat Srbiji','Telegram kojim je objavljen rat Srbiji',1),(44,'Zbog čega muzej koncentracionog logora nosi naziv \"12. februar\"?','Zato što se tad desilo bekstvo iz logora.','Zato što je to dan osnivanja logora.','Zato što je to dan kada je logor zatvoren.','Zato što se tad desilo bekstvo iz logora.',5),(45,'Koje godine je Gabrovački manastir živopisan?','1873.','1856.','1844.','1873.',4),(46,'Kada je podignuta Latinska crkva u okolini Niša?','U XII veku.','U XV veku.','U XI veku.','U XI veku.',4),(47,'U blizini kod sela se nalazi Latinska crkva?','Gornji Matejevac','Donji Matejevac','Gabrovac','Gornji Matejevac',4),(48,'Mošti kog sveca su čuvane u Crkvi Svetog Nikole?','Svetog Prokuplja','Svetog Nikole','Svetog Stefana','Svetog Prokuplja',4),(49,'Pored Crkve Svetog Nikole Osmanlije su podigle minaret, a hram nazvali \"Fetije\", što u prevodu znači:','uzdignuta','sveta','pokorena','pokorena',4),(50,'Koliko bekstava iz logora u Nišu se desilo?','Dva','Jedno','Nijedno','Dva',7),(51,'Koji značajan događaj se desio u Crkvi Svetog Pantelejmona?','Susret cara Dušana i Svetog Grigorija','Susret Stefana Nemanje i nemačkog cara Fridriha Barbarose','Premeštanje mošti Svetog Prokuplja','Susret Stefana Nemanje i nemačkog cara Fridriha Barbarose',4),(52,'Gde se nalazi crkva Svetog cara Konstantina i carice Jelene?','U parku Čair','U samom centru grada Niša','U parku Svetog Save','U parku Svetog Save',4),(53,'Šta se od navednog naazi najbliže Kameničkom visu?','Udruženje Zooplanet','Bojanine vode','Suva planina','Udruženje Zooplanet',15),(54,'Po čemu je Sićevačka klisura dobila ime?','Po reci Sićevo','Po planini Sićevo','Po selu Sićevo','Po selu Sićevo',15),(55,'Koji manastir se ne nalazi blizu Sićevačke klisure?','Manastir Svete Bogorodice','Manastir Svete Petke Iverice','Gabrovački manastir','Gabrovački manastir',15),(56,'Koji od navedenih nije naziv hidrocentrale u okolini Sićevačke klisure?','Sveta Petka','Sićevo','Kusač','Kusač',15),(57,'Gde se nalazi spomenik oslobodiocima Niša?','U parku Čair','Na Trgu kralja Aleksandra','U samom centru grada','U samom centru grada',14),(58,'Kalča je bio:','pas','nadimak Stevana Sremca','prijatelj Stevana Sremca','prijatelj Stevana Sremca',14),(59,'Koji čuveni imperator je rođen u Nišu?','Car Hostilijan','Car Konstantin','Car Klaudije','Car Konstantin',14),(60,'Ćele kula je nastala kao:','spomenik srpskoj pobedi na Čegru','upozorenje Srbima od Turaka','spomenik tragediji koja se desila na Čegru','upozorenje Srbima od Turaka',14),(61,'Kada je postavljen spomenik kralju Aleksandru?','1939.','1946.','1944.','1939.',14),(62,'Gde se nalazi arheološka sala?','Kod Ćele kule','Kod Medijane','U samom centru grada','U samom centru grada',14),(63,'Koja od sledećih izjava je netačna?','U Medijani se nekada nalazilo tursko kupatilo','Medijana je nekada bila predrađe antičkog grada','U Medijani se nalazila raskošna vila','U Medijani se nekada nalazilo tursko kupatilo',14),(64,'Koja pećina se nalazi u blizini Niša?','Cerska pećina','Prekonoška pećina','Cerjanska pećina','Cerjanska pećina',16),(65,'Koja je prosečna visina pećine?','od 15 do 40m','od 20 do 30m','od 15 do 30m','od 15 do 40m',16),(66,'Kada je ta pećina proglašena prirodnim dobrom?','2000.','1998.','1978.','1998.',16),(67,'Kada je podignut spomenik na Bubnju?','1809.','1980.','1963.','1963.',11),(68,'Gde je smeštena Niška banja?','Pored Nišave','U podnožju Svrljiških planina','U podnožju Koritnika','U podnožju Koritnika',12),(69,'Koja od narednih tvrdnji je tačna?','Voda u Niškoj banji spada u grupu hipertermalnih voda','Voda u Niškoj banji ima prosečnu temperaturu od 33°C','Voda u Niškoj banji ima povećanu količinu radona','Voda u Niškoj banji ima povećanu količinu radona',12);
/*!40000 ALTER TABLE `pitanja` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rezervacije`
--

DROP TABLE IF EXISTS `rezervacije`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `rezervacije` (
  `IdRezervacije` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `IdTuristeR` int(10) unsigned NOT NULL,
  `IdTureR` int(10) unsigned NOT NULL,
  `IdVodicaR` int(10) unsigned NOT NULL,
  `Datum` date DEFAULT NULL,
  `BrojOsoba` int(10) unsigned DEFAULT NULL,
  PRIMARY KEY (`IdRezervacije`),
  KEY `IdTuristeR_idx` (`IdTuristeR`),
  KEY `IdTureR_idx` (`IdTureR`),
  KEY `IdVodicaR_idx` (`IdVodicaR`),
  CONSTRAINT `IdTureR` FOREIGN KEY (`IdTureR`) REFERENCES `ture` (`IdTure`) ON DELETE CASCADE,
  CONSTRAINT `IdTuristeR` FOREIGN KEY (`IdTuristeR`) REFERENCES `turisti` (`IdTuriste`),
  CONSTRAINT `IdVodicaR` FOREIGN KEY (`IdVodicaR`) REFERENCES `vodici` (`IdVodica`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=41 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rezervacije`
--

LOCK TABLES `rezervacije` WRITE;
/*!40000 ALTER TABLE `rezervacije` DISABLE KEYS */;
INSERT INTO `rezervacije` VALUES (21,1,1,3,'2018-09-15',10),(22,8,1,3,'2020-06-30',5),(23,2,1,3,'2019-07-14',2),(24,7,1,3,'2020-07-15',2),(25,7,6,4,'2018-10-13',2),(26,7,10,5,'2020-08-30',2),(27,1,1,3,'2019-06-30',2),(29,6,12,2,'2020-06-28',6),(30,6,7,5,'2020-08-26',7),(31,6,6,4,'2019-06-30',2),(32,7,10,5,'2020-09-27',2),(33,7,7,5,'2020-07-24',5),(34,9,3,2,'2017-07-28',20),(35,9,3,2,'2018-09-29',20),(36,9,3,2,'2019-10-29',25),(37,9,3,2,'2020-08-18',27),(38,8,8,4,'2020-12-26',5),(39,8,4,9,'2017-07-03',8);
/*!40000 ALTER TABLE `rezervacije` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `slike`
--

DROP TABLE IF EXISTS `slike`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `slike` (
  `IdSlike` int(11) NOT NULL AUTO_INCREMENT,
  `IdZnamenitost` int(10) unsigned DEFAULT NULL,
  `Slika` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`IdSlike`),
  KEY `IdZnamenitost_idx` (`IdZnamenitost`),
  CONSTRAINT `IdZnamenitost` FOREIGN KEY (`IdZnamenitost`) REFERENCES `znamenitosti` (`IdZnamenitosti`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=61 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `slike`
--

LOCK TABLES `slike` WRITE;
/*!40000 ALTER TABLE `slike` DISABLE KEYS */;
INSERT INTO `slike` VALUES (1,1,'Tvrdjava1.jpg'),(2,1,'Tvrdjava2.jpg'),(3,1,'Tvrdjava3.jpg'),(4,2,'CeleKula.jpg'),(5,2,'CeleKula3.jpg'),(6,2,'CeleKula4.jpg'),(7,3,'Bubanj1.jpg'),(8,3,'Bubanj2.jpg'),(9,3,'Bubanj3.jpg'),(10,4,'Cegar3.jpg'),(11,4,'Cegar1.jpg'),(12,4,'Cegar5.jpg'),(13,4,'Cegar2.jpg'),(14,4,'Cegar4.jpg'),(15,5,'Medijana1.jpg'),(16,5,'Medijana2.jpg'),(17,5,'Medijana3.jpg'),(18,5,'Medijana4.jpg'),(19,6,'Logor1.jpg'),(20,6,'Logor2.jpg'),(21,6,'Logor3.jpg'),(22,7,'ArheoloskaSala1.jpg'),(23,7,'ArheoloskaSala2.jpg'),(24,7,'ArheoloskaSala3.jpg'),(25,8,'Oslobodioci1.jpg'),(26,8,'Oslobodioci2.jpg'),(27,8,'Oslobodioci3.jpg'),(28,9,'Kalca.jpg'),(29,10,'KraljA1.jpg'),(30,11,'CarK1.jpg'),(31,11,'CarK2.jpg'),(32,12,'CrkvaCarK3.jpg'),(33,12,'CrkvaCarK1.jpg'),(34,12,'CrkvaCarK2.jpg'),(35,13,'SaborniHram1.jpg'),(36,13,'SaborniHram2.jpg'),(37,14,'CrkvaPantelej2.jpg'),(38,14,'CrkvaPantelej1.jpg'),(39,15,'LatinskaCrkva1.jpg'),(40,15,'LatinskaCrkva2.jpg'),(41,16,'GabrovackiManastir1.jpg'),(42,16,'GabrovackiManastir2.jpg'),(43,16,'SvJovan1.jpg'),(44,17,'NiskaBanja1.jpg'),(45,17,'NiskaBanja2.jpg'),(46,17,'NiskaBanja3.jpg'),(47,17,'NiskaBanja5.jpg'),(48,17,'NiskaBanja6.jpg'),(49,18,'SicevackaKlisura2.jpg'),(50,18,'SicevackaKlisura3.jpg'),(51,18,'SicevackaKlisura4.jpg'),(52,18,'SicevackaKlisura5.jpg'),(53,18,'SicevackaKlisura6.jpg'),(54,18,'SicevackaKlisura7.jpg'),(55,20,'Pecina.jpg'),(56,21,'SuvaPlanina3.jpg'),(57,21,'SuvaPlanina2.jpg'),(58,1,'Tvrdjava2.jpg'),(59,1,'Tvrdjava2.jpg'),(60,1,'ArheoloskaSala.jpg');
/*!40000 ALTER TABLE `slike` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ture`
--

DROP TABLE IF EXISTS `ture`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ture` (
  `IdTure` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `NazivTure` varchar(100) NOT NULL,
  `DanOdrzavanja` varchar(45) DEFAULT NULL,
  `VremeOdrzavanja` varchar(45) DEFAULT NULL,
  `MestoPolaska` varchar(45) DEFAULT NULL,
  `Kapacitet` int(10) unsigned DEFAULT NULL,
  `IdVodica` int(10) unsigned DEFAULT NULL,
  `Opis` varchar(5000) DEFAULT NULL,
  `TipTure` varchar(1) NOT NULL,
  PRIMARY KEY (`IdTure`),
  KEY `IdVodica_idx` (`IdVodica`),
  CONSTRAINT `IdVodica` FOREIGN KEY (`IdVodica`) REFERENCES `vodici` (`IdVodica`) ON DELETE SET NULL
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ture`
--

LOCK TABLES `ture` WRITE;
/*!40000 ALTER TABLE `ture` DISABLE KEYS */;
INSERT INTO `ture` VALUES (1,'Istorija Niša','2 3 4 6','09:00','Trg kralja Milana (\"kod konja\")',40,3,'Ova tura obuhvata ključne istorijske znamenitosti, po kojima je Niš poznat. Tura je edukativnog karaktera i preporučujemo je svima koji žele da upoznaju Niš. \r\nPolazak je u 9 sati ujutru, \"kod konja\", odnosno na Trgu kralja Milana. Turu počinjemo baš na ovom trgu, gde ćemo videti Spomenik oslobodiocima Niša, a zatim se kroz Tvrđavu uputiti do spomenika nekadašnjeg koncentracionog logora.\r\nNakon toga polazimo do memorijalnog parka Bubanj, a zatim sledi obilazak spomenika na Čegru.\r\nNaposletku, odlazimo do Ćele kule, nakon čega našu turu završavamo u popodnevnim časovima.','T'),(2,'Tura za lep dan','5 6 0','10:00','Trg kralja Milana (\"kod konja\")',30,9,'Ukoliko želite da provedete opušten dan u prirodi, preporučujemo Vam ovu turu! \r\nOva tura obuhvata nekoliko znamenitosti u okolini Niša, koja su popularna izletišta. \r\nSamo za Vas, mi smo odabrali tri znamenitosti: Kamenički vis, Spomenik na Čegru i Memorijalni park Bubanj.\r\nKao što joj i samo ime kaže, ova tura je za jedan lep dan, baš iz razloga što su ove znamenitosti u prirodi.\r\nTura je namenjena za odmor i opuštanje uz par reči našeg vodiča. Ova tura ne uključuje nikakve naročite fizičke aktivnosti koje bi bile zamorne. ','T'),(3,'Školska tura','2 3 4','08:00','Ćele kula',40,2,'Ova tura je prvobitno namenjena za osnovne i srednje škole. Međutim, pogodna je i za svakoga ko želi da bolje upozna Niš! \r\nPolazak je kod Ćele kule, gde ćemo se prvo i zaustaviti i čuti par reči od našeg vodiča. Zatim slede ostale znamenitosti, u okolini i malo dalje.','T'),(4,'Opuštena tura za radni dan','1 2 3 4 5','16:00','Trg kralja Milana',30,9,'Ukoliko preostaje još par sati pre nego što istekne dan, a izašli biste negde sa nama, preporučujemo ovu turu! \r\nPogodna je za osobe svih uzrasta.','T'),(5,'Tura za mlade','4 5 6 0','09:00','Trg kralja Milana (\"kod konja\")',20,4,'Tura se preporučuje osobama koje su fizički aktivne. Uz našeg iskusnog vodiča, pogledajte i doživite neke od prirodnih znamenitosti u okolini Niša!','T'),(6,'Spomenici i muzeji','2 4','14:00','Trg kralja Milana',30,4,'Ova tura obuhvata sve spomenike i muzeje u Nišu.','T'),(7,'Kasna tura za šetnju','1 2 3 4 5 6 0','18:00','Trg kralja Milana',30,5,'Ukoliko biste pošli u šetnju i želite usput da čujete ponešto o znamenitostima u Nišu, na pravom ste mestu! Ova tura uključuje znamenitosti koje su u samom centru grada ili u blizini, a naš vodič će voditi turu umerenim tempom. Stoga je ova tura pogodna za svako veče kada biste malo da prošetate sa nama!','T'),(8,'Pećina i klisura','4 6','09:00','Trg Kralja Aleksandra',20,4,'Kao što i samo ime govori, ova tura obuhvata dve znamenitosti u okolini Niša - Cerjansku pećinu i Sićevačku klisuru. S obzirom na to da se očekuje vlažnost na ovoj turi, bez obzira na vremenske uslove, neophodno je da imate odgovarajuću obuću i budete pažljivi dok pratite našeg iskusnog vodiča.','T'),(9,'Ovo je Niš','3 5 0','11:00','Trg Kralja Aleksandra',30,10,'Samo jedna od naših tura o Nišu, ali dovoljna da doživite ovaj grad! Obuhvata znamenitosti po kojima je Niš poznat, koje ćete uz priču našeg vodiča pamtiti dugo.','T'),(10,'Okolina Niša','6 0','07:00','Trg kralja Milana (\"kod konja\")',25,5,'Tura koja obuhvata znamenitosti u okolini NIša. Uglavnom su u pitanju znamenitosti u prirodi, te je poželjno nositi odgovarajuću obuću.\r\nMože biti naporno na određenim deonicama.','T'),(11,'Crkve i manastiri','3 6 0','08:00','Trg kralja Milana',30,8,'Ova tura obuhvata sve crkve i manastire u samom Nišu, ali i okolini.','T'),(12,'Brza tura','2 3 4 5 6 0','12:00','Trg kralja Milana (\"kod konja\")',40,2,'Ukoliko ste u škripcu s vremenom, a želite da vidite sve ono po čemu je Niš poznat, priključite nam se u ovoj turi!\r\nImamo svega 5 znamenitosti u ovoj turi koja traje svega par sati, ali ćete uz nas čuti sve ono najvažnije o njima!','T');
/*!40000 ALTER TABLE `ture` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `turisti`
--

DROP TABLE IF EXISTS `turisti`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `turisti` (
  `IdTuriste` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `ImeTuriste` varchar(45) NOT NULL,
  `PrezimeTuriste` varchar(45) NOT NULL,
  `Pol` varchar(1) DEFAULT NULL,
  `DatumRodjenja` date DEFAULT NULL,
  `Email` varchar(45) NOT NULL,
  PRIMARY KEY (`IdTuriste`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `turisti`
--

LOCK TABLES `turisti` WRITE;
/*!40000 ALTER TABLE `turisti` DISABLE KEYS */;
INSERT INTO `turisti` VALUES (1,'Aleksandra','Jovanović','Ž','1998-12-16','aleksandra.jovanovic@elfak.rs'),(2,'Sara','Jovanović','Ž','1998-11-30','sara.jovanovic@elfak.rs'),(3,'Valentina','Jošanović','Ž','1998-10-07','valentina@elfak.rs'),(4,'Aleksa','Krstić','M','1998-04-04','aleksa.krsticc@elfak.rs'),(5,'Goran','Rakić','M','1997-05-15','goran.rakic@elfak.rs'),(6,'Jelena','Milošević','Ž','1975-05-14','jelenam@gmail.com'),(7,'Dušan','Nikolić','M','1986-06-30','dussann@hotmail.com'),(8,'Zoran','Petrović','M','1983-02-04','zokipetrovic@gmail.com'),(9,'Mirela','Stefanović','Ž','1965-05-14','miirelastefanovicc@gmail.com'),(10,'Ivan','Petrović','M','1988-08-08','ivann.npetrovic@hotmail.com'),(11,'Jana','Jovanović','Ž','1971-12-11','jana.jovannovic@gmail.com'),(12,'Kristina','Kostić','Ž','1990-10-15','kristtina.kosticc@gmail.com'),(13,'Marko','Denić','M','1996-09-13','marko.denicc@gmail.com'),(14,'Jovan','Filipović','M','1998-08-11','jovan.joca@elfak.rs'),(15,'Hristina','Kostić','Ž','1993-04-04','hrist.ina@hotmail.com'),(16,'Jelena','Mitrović','Ž','1991-04-05','jel.ena@elfak.rs'),(17,'Denis','Jelenković','M','1995-06-16','denis.jelen@gmail.com'),(18,'Uroš','Ivanović','M','1994-07-13','uros.uki@elfak.rs'),(19,'Kosta','Jelić','M','1999-10-14','kosta.jelic@elfak.rs'),(20,'Oliver','Minić','M','1989-01-11','oli.oliver@elfak.rs');
/*!40000 ALTER TABLE `turisti` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vodici`
--

DROP TABLE IF EXISTS `vodici`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vodici` (
  `IdVodica` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `ImeVodica` varchar(45) NOT NULL,
  `PrezimeVodica` varchar(45) NOT NULL,
  `Pol` varchar(1) NOT NULL,
  `BrojTelefona` varchar(45) DEFAULT NULL,
  `Licenca` varchar(45) DEFAULT NULL,
  `Ocena` decimal(4,2) DEFAULT NULL,
  `DatumRodjenja` date DEFAULT NULL,
  `Email` varchar(45) DEFAULT NULL,
  `Slika` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`IdVodica`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vodici`
--

LOCK TABLES `vodici` WRITE;
/*!40000 ALTER TABLE `vodici` DISABLE KEYS */;
INSERT INTO `vodici` VALUES (1,'Marijana','Mitić','Ž','061 0001111','Turistički vodič, turistički pratilac',NULL,'1991-10-15','marijanamitic@ont.rs','Vodic2.png'),(2,'Marko','Nikolić','M','061 0001112','Turistički vodič, strani jezici',7.66,'1977-02-21','markonikolic@ont.rs','Vodic8.png'),(3,'Stefan','Milenković','M','061 0001113','Turistički vodič, turizmolog',0.00,'1981-06-16','stefanmilenkovic@ont.rs','Vodic1.png'),(4,'Milica','Stanković','Ž','061 0001114','Turistički vodič',8.50,'1993-07-06','milicastankovic@ont.rs','Vodic3.png'),(5,'Srđan','Stošić','M','061 0001116','Profesionalna licenca, strani jezik',NULL,'1971-01-16','srdjanont@ont.rs','Vodic12.png'),(8,'Aleksandar','Ilić','M','061 0001115','Turistički pratioc',NULL,'1991-04-25','aleksandarilic@ont.rs','Vodic4.png'),(9,'Alisa','Anđelić','Ž','0610799807','Profesionalna, turistički prevodilac',9.00,'1965-05-09','alisaont@ont.rs','Vodic11.png'),(10,'Selena','Antić','Ž','0610799808','Turistički vodič',NULL,'1987-11-19','selenaont@ont.rs','Vodic10.png');
/*!40000 ALTER TABLE `vodici` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `znamenitosti`
--

DROP TABLE IF EXISTS `znamenitosti`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `znamenitosti` (
  `IdZnamenitosti` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `NazivZnamenitosti` varchar(45) NOT NULL,
  `Lokacija` varchar(100) DEFAULT NULL,
  `Opis` text,
  `RadnoVreme` varchar(500) DEFAULT NULL,
  `BrojTelefona` varchar(45) DEFAULT NULL,
  `CenaUlaznice` varchar(200) DEFAULT NULL,
  `Slika` varchar(100) DEFAULT NULL,
  `Tip` text,
  PRIMARY KEY (`IdZnamenitosti`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `znamenitosti`
--

LOCK TABLES `znamenitosti` WRITE;
/*!40000 ALTER TABLE `znamenitosti` DISABLE KEYS */;
INSERT INTO `znamenitosti` VALUES (1,'Tvrđava','Đuke Dinić','Stare, čvrste, visoke zidine i kapije niške Tvrđave, koje se od prve polovine 18. veka uzdižu na desnoj obali Nišave, ubrajaju se među najlepše i najbolje očuvane na srednjem Balkanu. Istorija utvrđenja na ovome mestu počinje u 1. v.n.e. kada su rimske legije utirale put novoj svetskoj civilizaciji. Građena od strane Rimljana, Vizantinaca i Srba, tvrđava je rušena i obnavljana više puta, da bi joj konačan izgled dale Osmanlije 1730. godine. Niš je jedan od retkih gradova u svetu sa impozantnom tvrđavom u najužem centru čije se težište nije pomeralo tokom dva milenijuma. Osim dobro očuvanih masivnih kamenih zidina i kapija, u Tvrđavi se mogu videti brojni ostaci burne niške istorije.','Tvrđava je otvorena tokom cele godine 24 sata dnevno.',NULL,'Ulaz je slobodan. ','Tvrdjava.jpg','Atrakcije'),(2,'Ćele Kula','Bulevar Dr Zorana Đinđića','Ćele-kula na turskom, a na srpskom kula od ljudskih lobanja jedinstven je spomenik na svetu koji godišnje obiđe preko 30.000 posetilaca. Ovaj zastrašujući  spomenik sazidan je od lobanja srpskih ratnika nakon bitke na Čegru 1809. godine. Kako bi iskalio svoj bes zbog organizovane pobune protiv sultana, tadašnji osmanlijski zapovednik grada Huršid paša, naredio je da se kao opomena lokalnom stanovništvu sagradi kula od lobanja na putu za Carigrad.','Utorak – Petak 10.00  – 16.00 , Subota-Nedelja 10.00 – 15.00, Ponedeljkom: zatvoreno.','+381 18 222 228','Odrasli 200,00 din, deca 150,00 din, grupna karta za sve objekte muzeja – 300,00 din, grupna karta za sve objekte muzeja – učenci, studenti, penzioneri – 200,00','CeleKula1.jpg','Atrakcije'),(3,'Memorijalni park Bubanj','Vojvode Putnika - 3 km od centra Niša','Brdo Bubanj, udaljeno 3 km od cetnra grada, tokom Drugog svetskog rata bilo je mesto masovnih streljanja zarobljenika iz Koncentracionog logora u Nišu. Na stratištu je nakon oslobođenja podignut spomenik u obliku tri stisnute pesnice koje simbolizuju muškarca, ženu i dete, kao i njihov otpor prema zločinu. Pesnice su visoke 13, 14 i 16 metara i svojom monumentalnošću ostavljaju impresivan utisak na sve posetioce memorijalnog parka.',NULL,NULL,'Ulaz je slobodan.','Bubanj.jpg','Atrakcije'),(4,'Spomenik na Čegru','Brdo Čegar - 6 km od centra Niša','Na brdu Čegar, na mestu čuvene bitke iz Prvog srpskog ustanka podignut je spomenik u znak sećanja na hrabre ustanike i njihovog komandanta, vojvodu Stevana Sinđelića. Nakon bitke na Čegru, Osmanlije su od lobanja poginulih srpskih ratnika sagradili Ćele Kulu , jedan od najstrašnijih spomenika srpske istorije.',NULL,NULL,'Ulaz je slobodan.','Cegar.jpg','Atrakcije'),(5,'Medijana','Bulevar Cara Konstantina','Medijana je luksuzno predgrađe antičkog grada Naisussa (današnjeg Niša), koje je izgrađeno krajem III i početkom IV veka tokom vladavine rimskog cara Konstantina Velikog i njegovih naslednika. Danas je Medijana jedan od najznačajnih arheološki parkova u Srbiji, u kojem se na površini od 40 hektara mogu videti ostaci raskošne vile sa peristilom, ostaci dve ranohrišćanske crkve, delovi žitnice, vojničkih baraka i vodotornjeva. Posetioci takođe mogu videti i više od 1000 kvadratnih metara vrednih podnih mozaika, koji dočaravaju deo raskoši ove jedinstvene carske rezidencije.',NULL,NULL,'Odrasli 200,00 din, deca 150,00 din, grupna karta za sve objekte muzeja – 300,00 din, grupna karta za sve objekte muzeja – učenci, studenti, penzioneri 200,00 din.','Medijana.jpg','Muzeji'),(6,'Koncentracioni logor','Bulevar 12. februar bb','Koncentracioni logor na Crvenom krstu predstavlja jedan od malobrojnih sačuvanih fašističkih logora u Evropi, koji i danas na autentičan način svedoči o stradanju komunista, partizana, srpskog, romskog i jevrejskog stanovništva za vreme nemačke okupacije Niša i Srbije ( 1941- 1944.). Kompleks logora zauziima površinu od 7 hektara i ograđen je visokim zidom i bodljikavom žicom. U njemu se nalazi glavna logorska zgrada, dve pomoćne prizemne zgrade, dva tornja, dve osmatračnice, stražare i česme. U glavnoj logorskoj zgradi koja je pretvorena u muzejski kompleks, posetioci mogu da vide samice, prostorije u kojima su boravile grupe zatvorenika, njihove potresne poruke na zidovima, kao i lične predmete kao što su dokumenta, pisma i fotografije.','Utorak – Petak 10.00 – 16.00, Subota-Nedelja 10.00 – 15.00, Ponedeljkom: zatvoreno','+381 18 588 889','Odrasli 200,00 din, deca 150,00 din, grupna karta za sve objekte muzeja – 300,00 din, grupna karta za sve objekte muzeja – učenci, studenti, penzioneri 200,00 din.','Logor.jpg','Muzeji'),(7,'Arheološka sala','Nikole Pašića 59','U Arheološkoj sali Narodnog muzeja možete pogledati brojne eksponate koji će vam slikovito predstaviti deo istorijskog i civilizacijskog razvoja grada Niša od neolita do srednjeg veka.','Utorak – Petak 09.00 – 19.00, Subota – Nedelja 09.00 – 19.00, Ponedeljkom: zatvoreno.',NULL,'Odrasli 200,00 din, deca 150,00 din, grupna karta za sve objekte muzeja – 300,00 din, grupna karta za sve objekte muzeja – učenci, studenti, penzioneri 200,00 din.','ArheoloskaSala.jpg','Muzeji'),(8,'Spomenik oslobodiocima Niša','Trg kralja Milana','Spomenik oslobodiocima smešten je u samom centru grada, na Trgu kralja Milana i obeležava razdoblje oslobodilačkih ratova protiv Osmanlijske vladavine i tokom Prvog svetskog rata.',NULL,NULL,NULL,'Oslobodioci.jpg','Spomenici'),(9,'Spomenik Stevanu Sremcu i Kalči','Početak Kopitareve ulice (Kazandžijsko sokače)','Ovaj spomenik posvećen je Stevanu Sremcu, srpskom piscu realističkih romana s kraja XX veka i njegovom prijatelju Kalči, koji je ujedno i lik iz njegovog romana Ivkova slava. Spomenik je podignut na originalnom mestu kuće Živka Mijalkovića, poznatijeg kao „gazda Ivko“, bogatog zanatlije iz Niša. Došavši sa severa Srbije, bio je očaran neposrednošću, humorom i načinom života Nišlija, naročito njihovim govorom.',NULL,NULL,NULL,'Kalca.jpg','Spomenici'),(10,'Spomenik Kralju Aleksandru','Trg kralja Aleksandra Karađorđevića','Prvobitni spomenik kralju Aleksandru, postavljen je 1939. godine, ali je već u prvim godinama po uspostavljanju komunističke vlasti u Srbiji, 1946. godine uklonjen i uništen. Novi spomenik kralju Aleksandru I Karađorđeviću podignut je 2004. godine u čast vladara koji je začetnik ideje o stvaranju Kraljevine Srba, Hrvata i Slovenaca. Spomenik je rad beogradskog vajara Zorana Ivanovića.',NULL,NULL,NULL,'KraljA.jpg','Spomenici'),(11,'Spomen obeležje caru Konstantinu','Početak tvrđavskog mosta','Spomen-obeležje najznačajnijem rimskom imperatoru rođenom u Nišu simbolično je podignuto na početku mosta na Nišavi koji vodi ka Tvrđavi, u kojoj je Konstanin proveo veći deo svog detinjstva. Spomenik prikazuje lik cara Konstanina i Hristov monogram, simbol koji mu se ukazao na nebu noć pre bitke na Milvijskom mostu (312.)',NULL,NULL,NULL,'CarK.jpg','Spomenici'),(12,'Crkva Sv. cara Konstantina i carice Jelene','Park Svetog Save','Crkva Svetog cara Konstantina i carice Jelene posvećena je rimskom imperatoru rođenom u Nišu i njegovoj majci Jeleni.',NULL,'+381 18 535 333',NULL,'CrkvaCarK.jpg','Crkve i manastiri'),(13,'Saborni hram','Prijezdina br. 7','Saborni hram u Nišu zauzima značajno mesto u istoriji srpske umetnosti. Izgradnja crkve započeta je 18. oktobra 1856. godine i trajala je do 1872. godine. Osveštena je nakon oslobođenja Niša od Osmanlija.',NULL,'+381 18 521 510',NULL,'SaborniHram.jpg','Crkve i manastiri'),(14,'Crkva Sv. Pantelejmona','Kosovke devojke','Crkva Svetog Pantelejmona izgrađena je 1878. godine, odmah nakon oslobođenja Niša od Osmanlijske imperije. Na oko sto metara iznad današnjeg hrama pronađeni su ostaci prvobitne crkve, koju je sagradio veliki župan Stefan Nemanja. Oko crkve postoji nekoliko izvora vode za koje se veruje da imaju isceliteljska dejstva.',NULL,'+381 18 215 405',NULL,'CrkvaPantelej.jpg','Crkve i manastiri'),(15,'Latinska crkva','Selo Gornji Matejevac','Jedna od najstarijih crkava u Srbiji – Latinska crkva, nalazi se na brdu Metoh u blizini sela Gornji Matejevac u okolini Niša. Podignuta u prvoj polovini XI veka i jedna je od retkih, sačuvanih crkava iz vizantijskog perioda.',NULL,NULL,NULL,'LatinskaCrkva.jpg','Crkve i manastiri'),(16,'Gabrovački manastir','8 km od centra Niša, 2 km južno od sela Gabrovac','Crkva Svete Trojice ili Gabrovački manastir predstavlja oazu mira i duhovnosti nadomak centra grada, smeštena u podnožju planine Seličevice.',NULL,NULL,NULL,'GabrovackiManastir.jpg','Crkve i manastiri'),(17,'Manastir Sv. Jovan','Selo Gornji  Matejevac','Manatir Svetog Jovana smešten je 10 kilometara severoistočno od Niša, u selu Gornji Matejevac. Sadašnja crkva podignuta je na ostacima stare crkve iz 19. veka. Manastir Svetog Jovana je odigrao je važnu ulogu tokom bitaka za oslobođenje Niša od Osmaniljske vladavine. Za ikonu Svetog Jovana, koja se nalazi u manastiru, veruje se da ima lekovitu moć.',NULL,NULL,NULL,'SvJovan.jpg','Crkve i manastiri'),(18,'Niška Banja','Niška Banja se nalazi 10km jugoistočno od Niša.',NULL,NULL,NULL,NULL,'NiskaBanja4.jpg','Okolina Niša'),(19,'Sićevačka klisura','Sićevačka klisura se nalazi na međuarodnom putu Niš – Sofija, 14 km od centra Niša.','Klisura predstavlja impozantni deo kanjona Nišave i duga je 17 km. Nalazi se na važnom magistralnom pravcu Niš-Sofija i od Niša je udaljena 14 km. Tok reke Nišave usekao je čudesnu klisuru između severnih ogranaka Suve planine i južnih padina Svrljiških planina i napravila pravi raj za ljubitelje netaknute prirode, raftinga, alpinizma, planinarenja i paraglajdinga.',NULL,NULL,NULL,'SicevackaKlisura1.jpg','Okolina Niša'),(20,'Cerjanska pećina','14 km od Niša','Cerjanska pećinanalazi se na 14 km od Niša, pored sela Cerje po kome je i dobila naziv. Pećina otkriva predivan svet ispod zemlje satkan od kanala, hodnika i dvorana, kao i bogatstvo pećinskog nakita – stalaktita, stalagmita, heliktita, talasastih draperija, pećinskih korala i kristalnih cvetova. Prema procenama geologa, ova hidrološki aktivna pećina nastala je pre više od 2 miliona godina. Interesantno je da kraj pećine još uvek nije otkriven, a dužina istraženog dela je 6025 m.',NULL,NULL,NULL,'Pecina.jpg','Okolina Niša'),(21,'Suva planina','20 km od Niša','Suva planina se nalazi na udaljenosti od dvadeset kilometara od centra Niša, počinje od Niške Banje, a završava se u Lužničkoj kotlini. Prostire se pravcem severozapad-jugoistok, sa visinskom razlikom od 250m do 1810 m. Najviši vrhovi su Trem: (1810 m), Golemo Stražište (1714 m), Litica (1683 m), Sokolov kamen (1523 m) i Mosor (984 m).',NULL,NULL,NULL,'SuvaPlanina.jpg','Okolina Niša'),(22,'Kamenički vis','Kod Kamenice','Kamenički vis je omiljeno jednodnevno izletište Nišlija koje je udaljeno od grada 14 km. Smešten je na ograncima Svrljiških planina, iznad sela Kamenica po kome je i dobilo ime, na nadmorskoj visini od 750-800 m. Teren je blago formiran i pokriven niskim šumskim rastinjem. Na severnoj strani se nalazi Studeni kladenac – jedini izvor na ovom području.','Uvek otvoreno','-','Slobodan ulaz','KamenickiVis.jpg','Okolina Niša');
/*!40000 ALTER TABLE `znamenitosti` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `znamenitostiuturama`
--

DROP TABLE IF EXISTS `znamenitostiuturama`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `znamenitostiuturama` (
  `IdZnamenitostiUTurama` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `IdZnamenitostiZut` int(10) unsigned NOT NULL,
  `IdTureZut` int(10) unsigned NOT NULL,
  PRIMARY KEY (`IdZnamenitostiUTurama`),
  KEY `IdZnamenitostiZut_idx` (`IdZnamenitostiZut`),
  KEY `IdTureZut_idx` (`IdTureZut`),
  CONSTRAINT `IdTureZut` FOREIGN KEY (`IdTureZut`) REFERENCES `ture` (`IdTure`) ON DELETE CASCADE,
  CONSTRAINT `IdZnamenitostiZut` FOREIGN KEY (`IdZnamenitostiZut`) REFERENCES `znamenitosti` (`IdZnamenitosti`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=152 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `znamenitostiuturama`
--

LOCK TABLES `znamenitostiuturama` WRITE;
/*!40000 ALTER TABLE `znamenitostiuturama` DISABLE KEYS */;
INSERT INTO `znamenitostiuturama` VALUES (104,6,1),(105,4,1),(106,3,1),(107,2,1),(112,9,3),(113,7,3),(114,5,3),(115,4,3),(116,2,3),(117,6,12),(118,4,12),(119,3,12),(120,2,12),(121,1,12),(122,17,11),(123,16,11),(124,15,11),(125,14,11),(126,13,11),(127,12,11),(128,22,5),(129,20,5),(130,4,9),(131,3,9),(132,2,9),(133,22,10),(134,21,10),(135,20,8),(136,19,8),(137,18,4),(139,12,4),(140,11,7),(141,10,7),(142,9,7),(143,8,7),(144,1,7),(145,11,6),(146,10,6),(147,9,6),(148,8,6),(149,2,6),(150,8,1),(151,1,1);
/*!40000 ALTER TABLE `znamenitostiuturama` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-06-29 14:19:29
