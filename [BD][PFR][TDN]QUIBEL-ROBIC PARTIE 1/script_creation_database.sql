##V Final 1

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema Agence_Escapadeclientclientmaintenancemaintenancesejour
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `Agence_Escapade` DEFAULT CHARACTER SET utf8 ;
USE `Agence_Escapade` ;

-- -----------------------------------------------------
-- Table `Agence_Escapade`.`Client`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Agence_Escapade`.`Client` (
  `idClient` INT NOT NULL AUTO_INCREMENT,
  `nom` VARCHAR(45) NOT NULL,
  `prenom` VARCHAR(45) NOT NULL,
  `telephone` VARCHAR(45) NOT NULL,
  `email` VARCHAR(80) NOT NULL,
  PRIMARY KEY (`idClient`),
  UNIQUE INDEX `idClient_UNIQUE` (`idClient` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Agence_Escapade`.`Voiture`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Agence_Escapade`.`Voiture` (
  `idVoiture` INT NOT NULL AUTO_INCREMENT,
  `immat` VARCHAR(6) NOT NULL,
  `marque` VARCHAR(45) NOT NULL,
  `modele` VARCHAR(45) NOT NULL,
  `type` VARCHAR(45) NOT NULL,
  `nb_place` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idVoiture`),
  UNIQUE INDEX `idVoiture_UNIQUE` (`idVoiture` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Agence_Escapade`.`Location`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Agence_Escapade`.`Location` (
  `idLocation` INT NOT NULL AUTO_INCREMENT,
  `idVoiture` INT NOT NULL,
  PRIMARY KEY (`idLocation`),
  INDEX `idVoiture_idx` (`idVoiture` ASC),
  CONSTRAINT `idVoiture_location`
    FOREIGN KEY (`idVoiture`)
    REFERENCES `Agence_Escapade`.`Voiture` (`idVoiture`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `agence_escapade`.`Logement`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `agence_escapade`.`Logement` (
  `idLogement` INT NOT NULL AUTO_INCREMENT,
  `arrondissement_logement` VARCHAR(45) NULL,
  `Adresse` VARCHAR(100) NULL,
  `nbVoyageurs` INT NULL,
  PRIMARY KEY (`idLogement`))
ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `Agence_Escapade`.`Sejour`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Agence_Escapade`.`Sejour` (
  `idSejour` INT NOT NULL AUTO_INCREMENT,
  `idClient` INT NOT NULL,
  `idLocation` INT NOT NULL,
  `idLogement` INT,
  `theme` VARCHAR(45) NOT NULL,
  `date_debut` DATE NOT NULL,
  `date_fin` DATE NOT NULL,
  `arrondissement_sejour` VARCHAR(45) NOT NULL,
  `confirme` TINYINT NOT NULL,
  `note_client` INT,
  `nbVoyageurs` INT,
  PRIMARY KEY (`idSejour`),
  UNIQUE INDEX `idSejour_UNIQUE` (`idSejour` ASC),
  INDEX `idClient_idx` (`idClient` ASC),
  INDEX `idLocation_idx` (`idLocation` ASC),
  INDEX `idLogement_idx` (`idLogement` ASC),
  CONSTRAINT `idClient`
    FOREIGN KEY (`idClient`)
    REFERENCES `Agence_Escapade`.`Client` (`idClient`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `idLocation`
    FOREIGN KEY (`idLocation`)
    REFERENCES `Agence_Escapade`.`Location` (`idLocation`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `idLogement`
    FOREIGN KEY (`idLogement`)
    REFERENCES `Agence_Escapade`.`Logement` (`idLogement`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Agence_Escapade`.`Parking`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Agence_Escapade`.`Parking` (
  `idParking` INT NOT NULL AUTO_INCREMENT,
  `nom` VARCHAR(45) NOT NULL,
  `adresse` VARCHAR(45) NOT NULL,
  `arrondissement_parking` INT NOT NULL,
  PRIMARY KEY (`idParking`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Agence_Escapade`.`Controlleur`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Agence_Escapade`.`Controlleur` (
  `idControlleur` INT NOT NULL AUTO_INCREMENT,
  `nom` VARCHAR(45) NULL,
  PRIMARY KEY (`idControlleur`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Agence_Escapade`.`Maintenance`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Agence_Escapade`.`Maintenance` (
  `idMaintenance` INT NOT NULL AUTO_INCREMENT,
  `idVoiture` INT NOT NULL,
  `idControlleur` INT NOT NULL,
  `date` DATE NOT NULL,
  `type_maintenance` VARCHAR(200) NOT NULL,
  PRIMARY KEY (`idMaintenance`),
  INDEX `idVoiture_idx` (`idVoiture` ASC),
  INDEX `idControlleur_idx` (`idControlleur` ASC),
  CONSTRAINT `idVoiture_maintenance`
    FOREIGN KEY (`idVoiture`)
    REFERENCES `Agence_Escapade`.`Voiture` (`idVoiture`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `idControlleur`
    FOREIGN KEY (`idControlleur`)
    REFERENCES `Agence_Escapade`.`Controlleur` (`idControlleur`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Agence_Escapade`.`Stationnement`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Agence_Escapade`.`Stationnement` (
  `idStationnement` INT NOT NULL AUTO_INCREMENT,
  `idParking` INT NOT NULL,
  `idVoiture` INT NOT NULL,
  `numPlace` VARCHAR(2) NOT NULL,
  PRIMARY KEY (`idStationnement`),
  INDEX `idParking_idx` (`idParking` ASC),
  UNIQUE INDEX `idVoiture_UNIQUE` (`idVoiture` ASC),
  CONSTRAINT `idParking`
    FOREIGN KEY (`idParking`)
    REFERENCES `Agence_Escapade`.`Parking` (`idParking`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `idVoiture_stationnement`
    FOREIGN KEY (`idVoiture`)
    REFERENCES `Agence_Escapade`.`Voiture` (`idVoiture`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
