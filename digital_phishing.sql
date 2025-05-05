-- phpMyAdmin SQL Dump
-- version 4.5.4.1
-- http://www.phpmyadmin.net
--
-- Client :  localhost
-- Généré le :  Mar 09 Avril 2024 à 08:11
-- Version du serveur :  5.7.11
-- Version de PHP :  7.0.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `digital_phishing`
--

-- --------------------------------------------------------

--
-- Structure de la table `contrat`
--

CREATE TABLE `contrat` (
  `NumCollaboration` int(6) NOT NULL,
  `LettreAccordCollaboration` varchar(16) NOT NULL DEFAULT '',
  `EtatCollaboration` int(2) NOT NULL,
  `AgessaCollaboration` tinyint(1) NOT NULL,
  `FactureCollaboration` tinyint(1) NOT NULL,
  `MontantCollaboration` int(5) NOT NULL,
  `MontantNCollaboration` decimal(10,1) NOT NULL,
  `DatePaiementCollaboration` varchar(10) NOT NULL,
  `NumPigiste` int(4) NOT NULL,
  `NumMagazine` int(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contenu de la table `contrat`
--

INSERT INTO `contrat` (`NumCollaboration`, `LettreAccordCollaboration`, `EtatCollaboration`, `AgessaCollaboration`, `FactureCollaboration`, `MontantCollaboration`, `MontantNCollaboration`, `DatePaiementCollaboration`, `NumPigiste`, `NumMagazine`) VALUES
(19, '1m2p-la-59-70', 1, 1, 0, 144, '140.0', '01/09/2022', 70, 59);

-- --------------------------------------------------------

--
-- Structure de la table `magazine`
--

CREATE TABLE `magazine` (
  `NumMagazine` int(4) NOT NULL,
  `DateBouclageMagazine` varchar(10) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `DateSortieMagazine` varchar(10) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `DatePaiementMagazine` varchar(10) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `BudgetMagazine` int(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contenu de la table `magazine`
--

INSERT INTO `magazine` (`NumMagazine`, `DateBouclageMagazine`, `DateSortieMagazine`, `DatePaiementMagazine`, `BudgetMagazine`) VALUES
(59, '01/07/2022', '01/08/2022', '01/09/2022', 3500),
(60, '01/07/2022', '01/08/2022', '01/09/2022', 3500),
(61, '01/07/2022', '01/08/2022', '01/09/2022', 3500),
(62, '01/07/2022', '01/08/2022', '01/09/2022', 3500),
(63, '01/07/2022', '01/08/2022', '01/09/2022', 3500),
(64, '01/07/2022', '01/08/2022', '01/09/2022', 3500);

-- --------------------------------------------------------

--
-- Structure de la table `pigistes`
--

CREATE TABLE `pigistes` (
  `NumPigiste` int(11) NOT NULL,
  `NomPigiste` varchar(25) DEFAULT NULL,
  `PrenomPigiste` varchar(25) DEFAULT NULL,
  `AdressePigiste` varchar(50) DEFAULT NULL,
  `CPPigiste` varchar(6) DEFAULT NULL,
  `VillePigiste` varchar(30) DEFAULT NULL,
  `MailPigiste` varchar(50) DEFAULT NULL,
  `NumSecuPigiste` varchar(15) DEFAULT NULL,
  `ContratCadrePigiste` varchar(25) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contenu de la table `pigistes`
--

INSERT INTO `pigistes` (`NumPigiste`, `NomPigiste`, `PrenomPigiste`, `AdressePigiste`, `CPPigiste`, `VillePigiste`, `MailPigiste`, `NumSecuPigiste`, `ContratCadrePigiste`) VALUES
(70, 'bdd', 'Alex', '13 rue des lilas', '71000', 'Macon', 'alex@yopmail.fr', '1820696000000', 'cc-03'),
(71, 'bdd', 'Alex', '13 rue des lilas', '71000', 'Macon', 'alex@yopmail.fr', '1820696000000', 'cc-03'),
(72, 'bdd', 'Alex', '13 rue des lilas', '71000', 'Macon', 'alex@yopmail.fr', '1820696000000', 'cc-03'),
(73, 'bdd', 'Alex', '13 rue des lilas', '71000', 'Macon', 'alex@yopmail.fr', '1820696000000', 'cc-03'),
(74, 'bdd', 'Alex', '13 rue des lilas', '71000', 'Macon', 'alex@yopmail.fr', '1820696000000', 'cc-03');

--
-- Index pour les tables exportées
--

--
-- Index pour la table `contrat`
--
ALTER TABLE `contrat`
  ADD PRIMARY KEY (`NumCollaboration`),
  ADD UNIQUE KEY `NumPigiste` (`NumPigiste`);

--
-- Index pour la table `magazine`
--
ALTER TABLE `magazine`
  ADD PRIMARY KEY (`NumMagazine`);

--
-- Index pour la table `pigistes`
--
ALTER TABLE `pigistes`
  ADD PRIMARY KEY (`NumPigiste`);

--
-- AUTO_INCREMENT pour les tables exportées
--

--
-- AUTO_INCREMENT pour la table `contrat`
--
ALTER TABLE `contrat`
  MODIFY `NumCollaboration` int(6) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;
--
-- AUTO_INCREMENT pour la table `magazine`
--
ALTER TABLE `magazine`
  MODIFY `NumMagazine` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=65;
--
-- AUTO_INCREMENT pour la table `pigistes`
--
ALTER TABLE `pigistes`
  MODIFY `NumPigiste` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=75;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
