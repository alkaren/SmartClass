-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3307
-- Generation Time: Apr 30, 2020 at 02:13 PM
-- Server version: 10.4.6-MariaDB
-- PHP Version: 7.3.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `smartclassdb`
--

-- --------------------------------------------------------

--
-- Table structure for table `absen`
--

CREATE TABLE `absen` (
  `id_absen` varchar(10) NOT NULL,
  `id_kelas` varchar(10) NOT NULL,
  `id_matkul` varchar(50) NOT NULL,
  `NIM` varchar(10) NOT NULL,
  `total_hadir` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `jadwal`
--

CREATE TABLE `jadwal` (
  `id_jadwal` varchar(50) NOT NULL,
  `id_kelas` varchar(50) NOT NULL,
  `tanggal_jadwal` varchar(50) NOT NULL,
  `mata_kuliah` varchar(50) NOT NULL,
  `start_kuliah` varchar(50) NOT NULL,
  `finish_kuliah` varchar(50) NOT NULL,
  `total_kuliah` varchar(50) NOT NULL,
  `usemodel` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `kelas`
--

CREATE TABLE `kelas` (
  `id_kelas` varchar(50) NOT NULL,
  `nama_kelas` varchar(50) NOT NULL,
  `ip_cctv` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `log_tbl`
--

CREATE TABLE `log_tbl` (
  `absen_log` varchar(1000) NOT NULL,
  `nim` varchar(10) NOT NULL,
  `url_foto` text NOT NULL,
  `tanggal_absen` varchar(50) NOT NULL,
  `start_time` varchar(50) NOT NULL,
  `last_time` varchar(50) NOT NULL,
  `total_time` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `log_tbl`
--

INSERT INTO `log_tbl` (`absen_log`, `nim`, `url_foto`, `tanggal_absen`, `start_time`, `last_time`, `total_time`) VALUES
('1', 'Alka', '~/BuktiAbsen/Alka.jpg', '2020-04-29', '16:50:33', '16:58:57', '0');

-- --------------------------------------------------------

--
-- Table structure for table `mahasiswa`
--

CREATE TABLE `mahasiswa` (
  `id` varchar(50) NOT NULL,
  `NIM` varchar(10) NOT NULL,
  `Nama` varchar(50) NOT NULL,
  `Email` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `matkul_tbl`
--

CREATE TABLE `matkul_tbl` (
  `id_matkul` varchar(50) NOT NULL,
  `nama_matkul` varchar(50) NOT NULL,
  `total_jam` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `log_tbl`
--
ALTER TABLE `log_tbl`
  ADD PRIMARY KEY (`nim`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
