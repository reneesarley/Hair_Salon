-- phpMyAdmin SQL Dump
-- version 4.7.7
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Jul 20, 2018 at 11:07 PM
-- Server version: 5.6.38
-- PHP Version: 7.2.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `renee_sarley`
--
CREATE DATABASE IF NOT EXISTS `renee_sarley` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `renee_sarley`;

-- --------------------------------------------------------

--
-- Table structure for table `clients`
--

CREATE TABLE `clients` (
  `id` int(11) NOT NULL,
  `firstName` varchar(255) NOT NULL,
  `lastName` varchar(255) NOT NULL,
  `stylistId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `clients`
--

INSERT INTO `clients` (`id`, `firstName`, `lastName`, `stylistId`) VALUES
(2, 'Becky', 'Alex', 3),
(3, 'Blake', 'Washington', 1),
(4, 'Bob', 'Jones', 1),
(5, 'Robin', 'Burns', 2),
(6, 'Arnold', 'Sarley', 4),
(7, 'Steve', 'Jones', 3),
(8, 'Fred', 'Jones', 7);

-- --------------------------------------------------------

--
-- Table structure for table `specialties`
--

CREATE TABLE `specialties` (
  `id` bigint(20) UNSIGNED NOT NULL,
  `specialtyName` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `specialties`
--

INSERT INTO `specialties` (`id`, `specialtyName`) VALUES
(1, 'Cut - Long Hair'),
(2, 'Cut - Short Hair'),
(3, 'Deep Condition'),
(4, 'Buzz Cut');

-- --------------------------------------------------------

--
-- Table structure for table `stylists`
--

CREATE TABLE `stylists` (
  `id` int(11) NOT NULL,
  `firstName` varchar(255) NOT NULL,
  `lastName` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `stylists`
--

INSERT INTO `stylists` (`id`, `firstName`, `lastName`) VALUES
(1, 'Sammy', 'Brown'),
(2, 'Jason', 'Brown'),
(3, 'John', 'Alder'),
(4, 'Bess', 'Flanders'),
(5, 'Molly', 'Ringwald'),
(6, 'Jessica', 'Jones'),
(7, 'Kimmy', 'Schmidt'),
(8, 'Barbara', 'Banks');

-- --------------------------------------------------------

--
-- Table structure for table `stylists_specialties`
--

CREATE TABLE `stylists_specialties` (
  `id` int(11) NOT NULL,
  `stylist_id` int(11) NOT NULL,
  `specialty_id` int(11) NOT NULL,
  `cost` decimal(10,0) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `stylists_specialties`
--

INSERT INTO `stylists_specialties` (`id`, `stylist_id`, `specialty_id`, `cost`) VALUES
(16, 3, 2, NULL),
(17, 3, 3, NULL),
(18, 1, 1, NULL),
(19, 1, 3, NULL),
(20, 3, 4, NULL),
(21, 6, 1, NULL),
(22, 6, 2, NULL),
(23, 6, 3, NULL),
(24, 6, 4, NULL);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `clients`
--
ALTER TABLE `clients`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`);

--
-- Indexes for table `specialties`
--
ALTER TABLE `specialties`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`);

--
-- Indexes for table `stylists`
--
ALTER TABLE `stylists`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`);

--
-- Indexes for table `stylists_specialties`
--
ALTER TABLE `stylists_specialties`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `clients`
--
ALTER TABLE `clients`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `specialties`
--
ALTER TABLE `specialties`
  MODIFY `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `stylists`
--
ALTER TABLE `stylists`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `stylists_specialties`
--
ALTER TABLE `stylists_specialties`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
