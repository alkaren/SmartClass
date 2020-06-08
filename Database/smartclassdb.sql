-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 08, 2020 at 01:21 PM
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
-- Table structure for table `absen_tbl`
--

CREATE TABLE `absen_tbl` (
  `id_absen` varchar(10) NOT NULL,
  `nim` varchar(10) NOT NULL,
  `id_kelas` varchar(50) NOT NULL,
  `id_matkul` varchar(50) NOT NULL,
  `nid` varchar(50) NOT NULL,
  `url_foto` text NOT NULL,
  `tanggal_absen` varchar(50) NOT NULL,
  `start_detect` varchar(50) NOT NULL,
  `last_detect` varchar(50) NOT NULL,
  `total_hadir` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `absen_tbl`
--

INSERT INTO `absen_tbl` (`id_absen`, `nim`, `id_kelas`, `id_matkul`, `nid`, `url_foto`, `tanggal_absen`, `start_detect`, `last_detect`, `total_hadir`) VALUES
('1', 'Alka', 'C1', 'M2', '7654321', '', '2020-06-08', '18:13:01', '18:16:04', '00:03:03');

-- --------------------------------------------------------

--
-- Table structure for table `dosen_tbl`
--

CREATE TABLE `dosen_tbl` (
  `nid` varchar(50) NOT NULL,
  `nama_dosen` varchar(50) NOT NULL,
  `email_dosen` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `dosen_tbl`
--

INSERT INTO `dosen_tbl` (`nid`, `nama_dosen`, `email_dosen`) VALUES
('1234567', 'Wawan', 'wawan@pnj.ac.id'),
('7654321', 'Mamat', 'mamat@pnj.ac.id');

-- --------------------------------------------------------

--
-- Table structure for table `jadwal_tbl`
--

CREATE TABLE `jadwal_tbl` (
  `id_jadwal` varchar(50) NOT NULL,
  `id_ruang` varchar(50) NOT NULL,
  `id_kelas` varchar(50) NOT NULL,
  `nid` varchar(50) NOT NULL,
  `id_matkul` varchar(50) NOT NULL,
  `tanggal_jadwal` varchar(50) NOT NULL,
  `start_kuliah` varchar(50) NOT NULL,
  `finish_kuliah` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `jadwal_tbl`
--

INSERT INTO `jadwal_tbl` (`id_jadwal`, `id_ruang`, `id_kelas`, `nid`, `id_matkul`, `tanggal_jadwal`, `start_kuliah`, `finish_kuliah`) VALUES
('JD1', 'R1', 'C1', '1234567', 'M1', '2020-06-08', '08:00:00', '11:00:00'),
('JD2', 'R1', 'C1', '7654321', 'M2', '2020-06-08', '13:00:00', '19:00:00');

-- --------------------------------------------------------

--
-- Table structure for table `kelas_tbl`
--

CREATE TABLE `kelas_tbl` (
  `id_kelas` varchar(50) NOT NULL,
  `nama_kelas` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `kelas_tbl`
--

INSERT INTO `kelas_tbl` (`id_kelas`, `nama_kelas`) VALUES
('C1', 'CCIT6A'),
('C2', 'CCIT6B');

-- --------------------------------------------------------

--
-- Table structure for table `log_tbl`
--

CREATE TABLE `log_tbl` (
  `absen_log` varchar(1000) NOT NULL,
  `nim` varchar(10) NOT NULL,
  `id_kelas` varchar(50) NOT NULL,
  `id_matkul` varchar(50) NOT NULL,
  `nid` varchar(50) NOT NULL,
  `url_foto` text NOT NULL,
  `tanggal_absen` varchar(50) NOT NULL,
  `start_time` varchar(50) NOT NULL,
  `last_time` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `mahasiswa_tbl`
--

CREATE TABLE `mahasiswa_tbl` (
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
-- Dumping data for table `matkul_tbl`
--

INSERT INTO `matkul_tbl` (`id_matkul`, `nama_matkul`, `total_jam`) VALUES
('M1', 'Programming Web 3', '4'),
('M2', 'Project Kekhususan', '5');

-- --------------------------------------------------------

--
-- Table structure for table `ruangkuliah_tbl`
--

CREATE TABLE `ruangkuliah_tbl` (
  `id_ruang` varchar(50) NOT NULL,
  `nama_ruang` varchar(50) NOT NULL,
  `lokasi` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `ruangkuliah_tbl`
--

INSERT INTO `ruangkuliah_tbl` (`id_ruang`, `nama_ruang`, `lokasi`) VALUES
('R1', 'GSG1', 'Gedung GSG'),
('R2', 'AA1', 'Gedung AA');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `absen_tbl`
--
ALTER TABLE `absen_tbl`
  ADD PRIMARY KEY (`id_absen`);

--
-- Indexes for table `dosen_tbl`
--
ALTER TABLE `dosen_tbl`
  ADD PRIMARY KEY (`nid`);

--
-- Indexes for table `jadwal_tbl`
--
ALTER TABLE `jadwal_tbl`
  ADD PRIMARY KEY (`id_jadwal`);

--
-- Indexes for table `kelas_tbl`
--
ALTER TABLE `kelas_tbl`
  ADD PRIMARY KEY (`id_kelas`);

--
-- Indexes for table `log_tbl`
--
ALTER TABLE `log_tbl`
  ADD PRIMARY KEY (`nim`);

--
-- Indexes for table `matkul_tbl`
--
ALTER TABLE `matkul_tbl`
  ADD PRIMARY KEY (`id_matkul`);

--
-- Indexes for table `ruangkuliah_tbl`
--
ALTER TABLE `ruangkuliah_tbl`
  ADD PRIMARY KEY (`id_ruang`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
