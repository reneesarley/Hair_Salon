-- phpMyAdmin SQL Dump
-- version 4.7.7
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Jul 20, 2018 at 11:11 PM
-- Server version: 5.6.38
-- PHP Version: 7.2.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `renee_sarley_test`
--
CREATE DATABASE IF NOT EXISTS `renee_sarley_test` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `renee_sarley_test`;

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
(121, 'Cut - Long Hair'),
(122, 'Cut - Short Hair');

-- --------------------------------------------------------

--
-- Table structure for table `stylists`
--

CREATE TABLE `stylists` (
  `id` int(11) NOT NULL,
  `firstName` varchar(255) NOT NULL,
  `lastName` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

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
(1, 18, 2, NULL),
(2, 19, 3, NULL),
(3, 23, 6, NULL),
(4, 24, 7, NULL),
(5, 28, 10, NULL),
(6, 29, 11, NULL),
(7, 33, 14, NULL),
(8, 34, 15, NULL),
(9, 38, 18, NULL),
(10, 39, 19, NULL),
(11, 43, 22, NULL),
(12, 44, 23, NULL),
(13, 48, 26, NULL),
(14, 49, 27, NULL),
(15, 53, 30, NULL),
(16, 54, 31, NULL),
(17, 58, 34, NULL),
(18, 59, 35, NULL),
(19, 63, 38, NULL),
(20, 64, 39, NULL),
(21, 68, 42, NULL),
(22, 69, 43, NULL),
(23, 73, 46, NULL),
(24, 74, 47, NULL),
(25, 78, 50, NULL),
(26, 79, 51, NULL),
(27, 83, 54, NULL),
(28, 84, 55, NULL),
(29, 88, 58, NULL),
(30, 89, 59, NULL),
(31, 93, 62, NULL),
(32, 94, 63, NULL),
(33, 98, 66, NULL),
(34, 99, 67, NULL),
(35, 103, 70, NULL),
(36, 104, 71, NULL),
(37, 108, 74, NULL),
(38, 109, 75, NULL),
(39, 113, 78, NULL),
(40, 114, 79, NULL),
(41, 118, 82, NULL),
(42, 119, 83, NULL),
(43, 123, 86, NULL),
(44, 124, 87, NULL),
(45, 128, 90, NULL),
(46, 129, 91, NULL),
(47, 133, 94, NULL),
(48, 134, 95, NULL),
(49, 138, 98, NULL),
(50, 139, 99, NULL),
(51, 143, 102, NULL),
(52, 144, 103, NULL),
(53, 148, 106, NULL),
(54, 149, 107, NULL),
(55, 153, 110, NULL),
(56, 154, 111, NULL),
(57, 158, 114, NULL),
(58, 159, 115, NULL),
(59, 163, 118, NULL),
(60, 164, 119, NULL);

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
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=70;

--
-- AUTO_INCREMENT for table `specialties`
--
ALTER TABLE `specialties`
  MODIFY `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=123;

--
-- AUTO_INCREMENT for table `stylists`
--
ALTER TABLE `stylists`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=166;

--
-- AUTO_INCREMENT for table `stylists_specialties`
--
ALTER TABLE `stylists_specialties`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=61;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
