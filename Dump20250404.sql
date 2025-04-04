CREATE DATABASE  IF NOT EXISTS `livinparis` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `livinparis`;
-- MySQL dump 10.13  Distrib 8.0.40, for Win64 (x86_64)
--
-- Host: localhost    Database: livinparis
-- ------------------------------------------------------
-- Server version	8.0.40

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
-- Table structure for table `client`
--

DROP TABLE IF EXISTS `client`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `client` (
  `id_client` int NOT NULL AUTO_INCREMENT,
  `id_utilisateur` int NOT NULL,
  `type_client` enum('particulier','entreprise') DEFAULT NULL,
  PRIMARY KEY (`id_client`),
  KEY `id_utilisateur` (`id_utilisateur`),
  CONSTRAINT `client_ibfk_1` FOREIGN KEY (`id_utilisateur`) REFERENCES `utilisateur` (`id_utilisateur`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `client`
--

LOCK TABLES `client` WRITE;
/*!40000 ALTER TABLE `client` DISABLE KEYS */;
INSERT INTO `client` VALUES (1,12,'particulier'),(2,3,'particulier'),(3,4,'entreprise'),(4,5,'particulier'),(5,7,'particulier'),(6,10,'entreprise'),(7,13,'particulier'),(8,14,'particulier'),(9,15,'particulier'),(10,16,'entreprise'),(11,17,'particulier'),(12,19,'entreprise'),(13,22,'particulier'),(14,23,'particulier'),(15,24,'particulier'),(16,25,'particulier'),(17,26,'particulier');
/*!40000 ALTER TABLE `client` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `commande`
--

DROP TABLE IF EXISTS `commande`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `commande` (
  `id_commande` int NOT NULL AUTO_INCREMENT,
  `id_cuisinier` int DEFAULT NULL,
  `id_client` int DEFAULT NULL,
  `date_commande` datetime DEFAULT NULL,
  `id_plat` int DEFAULT NULL,
  PRIMARY KEY (`id_commande`),
  KEY `id_plat` (`id_plat`),
  KEY `id_cuisinier` (`id_cuisinier`),
  KEY `id_client` (`id_client`),
  CONSTRAINT `commande_ibfk_1` FOREIGN KEY (`id_plat`) REFERENCES `plat` (`id_plat`) ON DELETE CASCADE,
  CONSTRAINT `commande_ibfk_2` FOREIGN KEY (`id_cuisinier`) REFERENCES `cuisinier` (`id_cuisinier`) ON DELETE CASCADE,
  CONSTRAINT `commande_ibfk_3` FOREIGN KEY (`id_client`) REFERENCES `client` (`id_client`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `commande`
--

LOCK TABLES `commande` WRITE;
/*!40000 ALTER TABLE `commande` DISABLE KEYS */;
INSERT INTO `commande` VALUES (1,1,6,'2020-03-05 08:15:54',8),(2,2,7,'2021-06-09 17:54:21',7),(3,3,8,'2025-01-18 21:16:04',2),(4,1,9,'2024-12-26 09:04:43',4),(5,2,10,'2024-10-14 16:31:57',11);
/*!40000 ALTER TABLE `commande` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cuisinier`
--

DROP TABLE IF EXISTS `cuisinier`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cuisinier` (
  `id_cuisinier` int NOT NULL AUTO_INCREMENT,
  `id_utilisateur` int NOT NULL,
  `nb_etoile` int DEFAULT NULL,
  `avis_cuisinier` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id_cuisinier`),
  KEY `id_utilisateur` (`id_utilisateur`),
  CONSTRAINT `cuisinier_ibfk_1` FOREIGN KEY (`id_utilisateur`) REFERENCES `utilisateur` (`id_utilisateur`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cuisinier`
--

LOCK TABLES `cuisinier` WRITE;
/*!40000 ALTER TABLE `cuisinier` DISABLE KEYS */;
INSERT INTO `cuisinier` VALUES (1,6,3,'Spécialiste en cuisine française'),(2,2,5,'Cuisinière renommée pour ses desserts'),(3,8,4,'Passionné de cuisine méditerranéenne'),(4,1,2,'Débutante mais prometteuse en cuisine contemporaine'),(5,9,4,'Expert en cuisine française, reconnu pour ses plats traditionnels.'),(6,11,5,'Spécialiste des desserts et pâtisseries, innovant et créatif.'),(7,18,3,'Passionné de cuisine méditerranéenne, avec une touche de modernité.'),(8,25,5,NULL),(9,26,NULL,NULL);
/*!40000 ALTER TABLE `cuisinier` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `entreprise`
--

DROP TABLE IF EXISTS `entreprise`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `entreprise` (
  `id_entreprise` int NOT NULL AUTO_INCREMENT,
  `nom_entreprise` varchar(100) NOT NULL,
  `nom_referent` varchar(50) DEFAULT NULL,
  `id_client` int DEFAULT NULL,
  PRIMARY KEY (`id_entreprise`),
  KEY `id_client` (`id_client`),
  CONSTRAINT `entreprise_ibfk_1` FOREIGN KEY (`id_client`) REFERENCES `client` (`id_client`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `entreprise`
--

LOCK TABLES `entreprise` WRITE;
/*!40000 ALTER TABLE `entreprise` DISABLE KEYS */;
INSERT INTO `entreprise` VALUES (1,'Acme Corporation','Ruben Cohen',3),(2,'Tech Innovators','Marie Dupond',6),(3,'Green Solutions','Aude Mouillet',10),(4,'Future Systems','Jeon Jungkook',12);
/*!40000 ALTER TABLE `entreprise` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `livraison`
--

DROP TABLE IF EXISTS `livraison`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `livraison` (
  `id_livraison` int NOT NULL AUTO_INCREMENT,
  `id_cuisinier` int NOT NULL,
  `date_livraison` date NOT NULL,
  `zone_livraison` varchar(100) NOT NULL,
  PRIMARY KEY (`id_livraison`),
  KEY `id_cuisinier` (`id_cuisinier`),
  CONSTRAINT `livraison_ibfk_1` FOREIGN KEY (`id_cuisinier`) REFERENCES `cuisinier` (`id_cuisinier`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `livraison`
--

LOCK TABLES `livraison` WRITE;
/*!40000 ALTER TABLE `livraison` DISABLE KEYS */;
INSERT INTO `livraison` VALUES (1,1,'2025-04-10','Paris 17'),(2,2,'2025-04-11','Paris 18');
/*!40000 ALTER TABLE `livraison` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `livraison_commande`
--

DROP TABLE IF EXISTS `livraison_commande`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `livraison_commande` (
  `id_livraison` int NOT NULL,
  `id_commande` int NOT NULL,
  PRIMARY KEY (`id_livraison`,`id_commande`),
  KEY `id_commande` (`id_commande`),
  CONSTRAINT `livraison_commande_ibfk_1` FOREIGN KEY (`id_livraison`) REFERENCES `livraison` (`id_livraison`) ON DELETE CASCADE,
  CONSTRAINT `livraison_commande_ibfk_2` FOREIGN KEY (`id_commande`) REFERENCES `commande` (`id_commande`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `livraison_commande`
--

LOCK TABLES `livraison_commande` WRITE;
/*!40000 ALTER TABLE `livraison_commande` DISABLE KEYS */;
INSERT INTO `livraison_commande` VALUES (1,1),(2,2);
/*!40000 ALTER TABLE `livraison_commande` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `plat`
--

DROP TABLE IF EXISTS `plat`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `plat` (
  `id_plat` int NOT NULL AUTO_INCREMENT,
  `nom_plat` varchar(50) DEFAULT NULL,
  `prix` double DEFAULT NULL,
  `quantite` int DEFAULT NULL,
  `type_plat` enum('entrée','plat','dessert') DEFAULT NULL,
  `date_fabrication` date DEFAULT NULL,
  `date_peremption` date DEFAULT NULL,
  `regime` varchar(50) DEFAULT NULL,
  `origine` varchar(50) DEFAULT NULL,
  `description_recette` text,
  `id_cuisinier` int DEFAULT NULL,
  `photo` tinyblob,
  `id_recette` int DEFAULT NULL,
  PRIMARY KEY (`id_plat`),
  KEY `id_recette` (`id_recette`),
  KEY `id_cuisinier` (`id_cuisinier`),
  CONSTRAINT `plat_ibfk_1` FOREIGN KEY (`id_recette`) REFERENCES `recette` (`id_recette`) ON DELETE CASCADE,
  CONSTRAINT `plat_ibfk_2` FOREIGN KEY (`id_cuisinier`) REFERENCES `cuisinier` (`id_cuisinier`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `plat`
--

LOCK TABLES `plat` WRITE;
/*!40000 ALTER TABLE `plat` DISABLE KEYS */;
INSERT INTO `plat` VALUES (1,'Raclette',10,6,'plat','2025-01-10','2025-01-15','Française','France','raclette, pommes de terre, jambon, cornichon',1,NULL,NULL),(2,'Salade de fruits',5,6,'dessert','2025-01-10','2025-01-15','Végétarien','Indifférent','fraise, kiwi, sucre',1,NULL,NULL),(3,'Pizza Margherita',8.5,10,'plat','2025-02-01','2025-02-05','Italienne','Italie','pâte, sauce tomate, mozzarella, basilic',2,NULL,NULL),(4,'Boeuf Bourguignon',12,5,'plat','2025-02-02','2025-02-10','Française','France','bœuf, vin rouge, champignons, carottes, oignons',3,NULL,NULL),(5,'Tarte aux pommes',6,8,'dessert','2025-02-03','2025-02-07','Végétarien','France','pommes, pâte brisée, cannelle, sucre',1,NULL,NULL),(6,'Quiche Lorraine',7.5,7,'plat','2025-02-04','2025-02-08','Française','France','pâte, lardons, crème, œufs, fromage',2,NULL,NULL),(7,'Crème brûlée',5.5,10,'dessert','2025-02-05','2025-02-12','Végétarien','France','crème, sucre, œufs, vanille',3,NULL,NULL),(8,'Sushi',12,8,'plat','2025-03-10','2025-03-15','Pescetarien','Japon','riz, poisson cru, algues, wasabi',4,NULL,NULL),(9,'Ratatouille',9,10,'plat','2025-03-12','2025-03-18','Végétarien','France','aubergine, courgette, tomate, poivron, herbes de Provence',2,NULL,NULL),(10,'Falafel',7,12,'plat','2025-03-11','2025-03-17','Végétarien','Moyen-Orient','pois chiches, épices, tahini, pita',5,NULL,NULL),(11,'Tacos',8,9,'plat','2025-03-13','2025-03-20','Omnivore','Mexique','tortilla, viande assaisonnée, salsa, fromage, guacamole',3,NULL,NULL),(12,'Panna Cotta',6.5,8,'dessert','2025-03-14','2025-03-21','Végétarien','Italie','crème, sucre, gélatine, vanille, coulis de fruits',4,NULL,NULL),(13,'Biryani',11,6,'plat','2025-03-15','2025-03-22','Omnivore','Inde','riz, épices, poulet, yaourt, coriandre',6,NULL,NULL),(14,'Pad Thaï',10.5,7,'plat','2025-03-16','2025-03-23','Omnivore','Thaïlande','nouilles de riz, crevettes, tofu, cacahuètes, citron vert',5,NULL,NULL),(15,'Baklava',5,10,'dessert','2025-03-17','2025-03-24','Végétarien','Turquie','pâte filo, noix, miel, sirop',7,NULL,NULL),(16,'Ceviche',13,5,'plat','2025-03-18','2025-03-25','Pescetarien','Pérou','poisson cru, citron vert, oignon, coriandre, piment',4,NULL,NULL),(17,'Goulash',9.5,8,'plat','2025-03-19','2025-03-26','Omnivore','Hongrie','bœuf, paprika, oignon, tomate, bouillon',3,NULL,NULL);
/*!40000 ALTER TABLE `plat` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `recette`
--

DROP TABLE IF EXISTS `recette`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `recette` (
  `id_recette` int NOT NULL AUTO_INCREMENT,
  `nom_recette` varchar(50) NOT NULL,
  `description_recette` text,
  `date_creation` datetime DEFAULT NULL,
  `id_cuisinier` int NOT NULL,
  `id_recette_origine` int DEFAULT NULL,
  PRIMARY KEY (`id_recette`),
  KEY `id_cuisinier` (`id_cuisinier`),
  KEY `id_recette_origine` (`id_recette_origine`),
  CONSTRAINT `recette_ibfk_1` FOREIGN KEY (`id_cuisinier`) REFERENCES `cuisinier` (`id_cuisinier`) ON DELETE CASCADE,
  CONSTRAINT `recette_ibfk_2` FOREIGN KEY (`id_recette_origine`) REFERENCES `recette` (`id_recette`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `recette`
--

LOCK TABLES `recette` WRITE;
/*!40000 ALTER TABLE `recette` DISABLE KEYS */;
INSERT INTO `recette` VALUES (1,'Raclette','Recette pour Raclette : raclette, pommes de terre, jambon, cornichon','2025-01-09 08:00:00',1,NULL),(2,'Salade de fruits','Recette pour Salade de fruits : fraise, kiwi, sucre','2025-01-09 09:00:00',1,NULL),(3,'Pizza Margherita','Recette pour Pizza Margherita : pâte, sauce tomate, mozzarella, basilic','2025-01-31 12:00:00',2,NULL),(4,'Boeuf Bourguignon','Recette pour Boeuf Bourguignon : bœuf, vin rouge, champignons, carottes, oignons','2025-02-01 14:00:00',3,NULL),(5,'Tarte aux pommes','Recette pour Tarte aux pommes : pommes, pâte brisée, cannelle, sucre','2025-02-02 16:00:00',1,NULL),(6,'Quiche Lorraine','Recette pour Quiche Lorraine : pâte, lardons, crème, œufs, fromage','2025-02-03 11:00:00',2,NULL),(7,'Crème brûlée','Recette pour Crème brûlée : crème, sucre, œufs, vanille','2025-02-04 17:00:00',3,NULL),(8,'Sushi','Recette pour Sushi : riz, poisson cru, algues, wasabi','2025-03-09 13:00:00',4,NULL),(9,'Ratatouille','Recette pour Ratatouille : aubergine, courgette, tomate, poivron, herbes de Provence','2025-03-10 12:00:00',2,NULL),(10,'Falafel','Recette pour Falafel : pois chiches, épices, tahini, pita','2025-03-10 14:00:00',5,NULL),(11,'Tacos','Recette pour Tacos : tortilla, viande assaisonnée, salsa, fromage, guacamole','2025-03-11 15:00:00',3,NULL),(12,'Panna Cotta','Recette pour Panna Cotta : crème, sucre, gélatine, vanille, coulis de fruits','2025-03-12 10:00:00',4,NULL),(13,'Biryani','Recette pour Biryani : riz, épices, poulet, yaourt, coriandre','2025-03-13 12:00:00',6,NULL),(14,'Pad Thaï','Recette pour Pad Thaï : nouilles de riz, crevettes, tofu, cacahuètes, citron vert','2025-03-14 14:00:00',5,NULL),(15,'Baklava','Recette pour Baklava : pâte filo, noix, miel, sirop','2025-03-15 16:00:00',7,NULL),(16,'Ceviche','Recette pour Ceviche : poisson cru, citron vert, oignon, coriandre, piment','2025-03-16 18:00:00',4,NULL),(17,'Goulash','Recette pour Goulash : bœuf, paprika, oignon, tomate, bouillon','2025-03-17 20:00:00',3,NULL);
/*!40000 ALTER TABLE `recette` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `transaction`
--

DROP TABLE IF EXISTS `transaction`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `transaction` (
  `id_transaction` int NOT NULL AUTO_INCREMENT,
  `montant_total` decimal(10,2) NOT NULL,
  `date_paiement` datetime DEFAULT NULL,
  `moyen_paiement` enum('carte bancaire','especes') NOT NULL,
  PRIMARY KEY (`id_transaction`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transaction`
--

LOCK TABLES `transaction` WRITE;
/*!40000 ALTER TABLE `transaction` DISABLE KEYS */;
INSERT INTO `transaction` VALUES (1,45.50,'2025-04-01 14:30:00','carte bancaire'),(2,30.00,'2025-04-02 10:15:00','especes'),(3,55.75,'2025-04-03 18:45:00','carte bancaire'),(4,22.00,'2025-04-04 12:00:00','especes'),(5,60.00,'2025-04-05 20:30:00','carte bancaire');
/*!40000 ALTER TABLE `transaction` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `transaction_commande`
--

DROP TABLE IF EXISTS `transaction_commande`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `transaction_commande` (
  `id_transaction` int NOT NULL,
  `id_commande` int NOT NULL,
  PRIMARY KEY (`id_transaction`,`id_commande`),
  KEY `id_commande` (`id_commande`),
  CONSTRAINT `transaction_commande_ibfk_1` FOREIGN KEY (`id_transaction`) REFERENCES `transaction` (`id_transaction`) ON DELETE CASCADE,
  CONSTRAINT `transaction_commande_ibfk_2` FOREIGN KEY (`id_commande`) REFERENCES `commande` (`id_commande`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transaction_commande`
--

LOCK TABLES `transaction_commande` WRITE;
/*!40000 ALTER TABLE `transaction_commande` DISABLE KEYS */;
INSERT INTO `transaction_commande` VALUES (1,1),(2,2);
/*!40000 ALTER TABLE `transaction_commande` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `utilisateur`
--

DROP TABLE IF EXISTS `utilisateur`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `utilisateur` (
  `id_utilisateur` int NOT NULL AUTO_INCREMENT,
  `nom` varchar(50) DEFAULT NULL,
  `prenom` varchar(50) DEFAULT NULL,
  `email` varchar(50) NOT NULL,
  `mot_de_passe` varchar(50) NOT NULL,
  `telephone` varchar(50) DEFAULT NULL,
  `numero_de_rue` int DEFAULT NULL,
  `rue` varchar(50) DEFAULT NULL,
  `code_postal` int DEFAULT NULL,
  `ville` varchar(50) DEFAULT NULL,
  `metro` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id_utilisateur`),
  UNIQUE KEY `email` (`email`)
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `utilisateur`
--

LOCK TABLES `utilisateur` WRITE;
/*!40000 ALTER TABLE `utilisateur` DISABLE KEYS */;
INSERT INTO `utilisateur` VALUES (1,'Bernorie','Louane','L.Bernorie@gmail.com','mdp123','1234567891',645,'Rue Ribéra',75016,'Paris','Jasmin'),(2,'Moripet','Victor','VictorMoripet@gmail.com','soleil654','1234567892',18,'Rue des Volontaires',75015,'Paris','Volontaires'),(3,'Cao','Lily','lilycao@gmail.com','passd123','1234567893',65,'Avenue du Général Leclerc',75014,'Paris','Alésia'),(4,'Cohen','Ruben','R.cohen05@gmail.com','word123','1234567894',6,'Rue de la Pompe',75016,'Paris','La Muette'),(5,'Petroni','Arthur','A.petroni@gmail.com','mdp588','1234567895',43,'Rue Vavin',75006,'Paris','Vavin'),(6,'Perez','Emilia','EmiliaP@gmail.com','password873','1234567896',7,'Rue Clément',75006,'Paris','Mabillon'),(7,'Dubar','Ludovic','ludo.dubar@gmail.com','chaise679','1234567897',3,'Rue Lassus',75019,'Paris','Jourdain'),(8,'Houlet','Pierre','PierreHoulet@gmail.com','sword614','1234567898',103,'Rue Blanche',75009,'Paris','Blanche'),(9,'Gouronne','Raphael','RaphGouronne@gmail.com','fleur546','1234567899',51,'Rue de Rome',75008,'Paris','Europe'),(10,'Dupond','Marie','Mdupond@gmail.com','password123','1234567880',30,'Rue de la République',75011,'Paris','République'),(11,'Durand','Medhy','Mdurand@gmail.com','password123','1234567881',15,'Rue Cardinet',75017,'Paris','Cardinet'),(12,'Chamy','Chloe','ChloeChamy@gmail.com','pass819','1234567882',1,'Rue des Bauches',75016,'Paris','La Muette'),(13,'lamoie','george','G.lam@gmail.com','momo99','1234567883',15,'Rue Carrier-Belleuse',75015,'Paris','Cambronne'),(14,'David','Camille','C.David@gmail.com','pop84','123456784',29,'Rue Dussoubs',75002,'Paris','Sentier'),(15,'Parvizi','Lianne','parvizi.lianne@gmail.com','hkjqdfjr','123456785',12,'Rue de la Grange Batelière',75009,'Paris','Jourdain'),(16,'Mouillet','Aude','aude.mouillet@gmail.com','chickenkfc','123456786',13,'Rue Blanche',75009,'Paris','Blanche'),(17,'Amouyal','Celia','celia.amouyal@gmail.com','fleurlilac','123456787',41,'Rue de Rome',75008,'Paris','Europe'),(18,'Kim','Jennie','jennie.kim@gmail.com','passwordblackpink','123456788',12,'Rue de la République',75011,'Paris','République'),(19,'Jeon','Jungkook','jungkook.jeon@gmail.com','passwordbts','123456789',5,'Rue Cardinet',75017,'Paris','Cardinet'),(21,'chams','chloche','chlo.chams@gmail.com','mdgp','0977822554',2,'Rue des Bauches',75016,'paris','La Muette'),(22,'champi','chouchou','chouchou.champi@gmail.com','mama','0966548872',2,'rue des bauches',75016,'paris','La Muette'),(23,'mama','momo','mama.m@gmail.com','mafi','0588946621',3,'Rue des Bauches',75016,'Paris','La Muette'),(24,'lala','lolo','lola@gmail.com','mipo','0166753345',6,'Rue de lo=\'eau',75016,'Paris','La Muette'),(25,'mam','lou','lou.mama@gmail.com','mopu','5433986674',7,'Rue des Bauches',75016,'Paris','La Muette'),(26,'loulou','benoit','ben.Loulou@gmail.com','loulou','4577126654',8,'Rue de Clichy',75015,'Paris','Nation');
/*!40000 ALTER TABLE `utilisateur` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-04-04 17:28:04
