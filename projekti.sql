--
-- PostgreSQL database dump
--

-- Dumped from database version 9.6.15
-- Dumped by pg_dump version 9.6.15

-- Started on 2019-12-05 18:43:04

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 1 (class 3079 OID 12387)
-- Name: plpgsql; Type: EXTENSION; Schema: -; Owner: 
--

CREATE EXTENSION IF NOT EXISTS plpgsql WITH SCHEMA pg_catalog;


--
-- TOC entry 2158 (class 0 OID 0)
-- Dependencies: 1
-- Name: EXTENSION plpgsql; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION plpgsql IS 'PL/pgSQL procedural language';


SET default_tablespace = '';

SET default_with_oids = false;

--
-- TOC entry 187 (class 1259 OID 16597)
-- Name: huollot; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.huollot (
    "ID" integer NOT NULL,
    "id_varastoNimike" integer,
    id_venttiili integer,
    "PVM" date
);


ALTER TABLE public.huollot OWNER TO postgres;

--
-- TOC entry 188 (class 1259 OID 16619)
-- Name: ostot; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.ostot (
    "ID" integer NOT NULL,
    "id_Varastonimike" integer,
    "PVM" date,
    "Määrä" integer
);


ALTER TABLE public.ostot OWNER TO postgres;

--
-- TOC entry 185 (class 1259 OID 16575)
-- Name: varastonimike; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.varastonimike (
    id integer NOT NULL,
    nimi character varying(255) NOT NULL,
    valmistaja character varying(255),
    "myyjä" character varying(255),
    hinta integer,
    saldo integer,
    minimisaldo integer
);


ALTER TABLE public.varastonimike OWNER TO postgres;

--
-- TOC entry 186 (class 1259 OID 16583)
-- Name: venttiili; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.venttiili (
    id integer NOT NULL,
    nimi character varying(255),
    valmistaja character varying(255),
    malli character varying(255),
    koko integer,
    id_varastonimike integer,
    seuraava_huolto date,
    huollettu date,
    huoltovali_vuosina integer
);


ALTER TABLE public.venttiili OWNER TO postgres;

--
-- TOC entry 2149 (class 0 OID 16597)
-- Dependencies: 187
-- Data for Name: huollot; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.huollot ("ID", "id_varastoNimike", id_venttiili, "PVM") VALUES (1, 300001, 40001, '2018-11-13');


--
-- TOC entry 2150 (class 0 OID 16619)
-- Dependencies: 188
-- Data for Name: ostot; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.ostot ("ID", "id_Varastonimike", "PVM", "Määrä") VALUES (1, 300001, '2018-12-29', 2);


--
-- TOC entry 2147 (class 0 OID 16575)
-- Dependencies: 185
-- Data for Name: varastonimike; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.varastonimike (id, nimi, valmistaja, "myyjä", hinta, saldo, minimisaldo) VALUES (300001, 'LKB-F 25', 'Alfa-Laval', 'TetraPak', 70, 2, 2);
INSERT INTO public.varastonimike (id, nimi, valmistaja, "myyjä", hinta, saldo, minimisaldo) VALUES (300002, 'LKB-F 38', 'Alfa-Laval', 'TetraPak', 95, 2, 2);
INSERT INTO public.varastonimike (id, nimi, valmistaja, "myyjä", hinta, saldo, minimisaldo) VALUES (300003, 'LKB-F 51', 'Alfa-Laval', 'TetraPak', 105, 2, 2);
INSERT INTO public.varastonimike (id, nimi, valmistaja, "myyjä", hinta, saldo, minimisaldo) VALUES (300004, 'LKB-F 63', 'Alfa-Laval', 'TetraPak', 120, 2, 2);
INSERT INTO public.varastonimike (id, nimi, valmistaja, "myyjä", hinta, saldo, minimisaldo) VALUES (300005, 'Unique SSV 51', 'Alfa-Laval', 'TetraPak', 95, 2, 2);
INSERT INTO public.varastonimike (id, nimi, valmistaja, "myyjä", hinta, saldo, minimisaldo) VALUES (300006, 'Unique SSV 63', 'Alfa-Laval', 'TetraPak', 105, 2, 2);
INSERT INTO public.varastonimike (id, nimi, valmistaja, "myyjä", hinta, saldo, minimisaldo) VALUES (300007, 'Unique SSV 76', 'Alfa-Laval', 'TetraPak', 120, 2, 2);
INSERT INTO public.varastonimike (id, nimi, valmistaja, "myyjä", hinta, saldo, minimisaldo) VALUES (300008, 'SW43 51', 'SPX', 'Flow Serve', 95, 2, 2);
INSERT INTO public.varastonimike (id, nimi, valmistaja, "myyjä", hinta, saldo, minimisaldo) VALUES (300009, 'SW43 63', 'SPX', 'Flow Serve', 105, 2, 2);
INSERT INTO public.varastonimike (id, nimi, valmistaja, "myyjä", hinta, saldo, minimisaldo) VALUES (300010, 'SW43 76', 'SPX', 'Flow Serve', 120, 2, 2);
INSERT INTO public.varastonimike (id, nimi, valmistaja, "myyjä", hinta, saldo, minimisaldo) VALUES (300012, 'sdg', 'aadsg', '123', 23, 3, 3);
INSERT INTO public.varastonimike (id, nimi, valmistaja, "myyjä", hinta, saldo, minimisaldo) VALUES (300011, 'sdfh', 'sdfh', 'sdfh', 34, 32, 34);


--
-- TOC entry 2148 (class 0 OID 16583)
-- Dependencies: 186
-- Data for Name: venttiili; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.venttiili (id, nimi, valmistaja, malli, koko, id_varastonimike, seuraava_huolto, huollettu, huoltovali_vuosina) VALUES (40001, 'Vesiventtiili', 'Alfa-Laval', 'LKB-F', 25, 300001, '2020-11-20', '2019-11-24', 3);
INSERT INTO public.venttiili (id, nimi, valmistaja, malli, koko, id_varastonimike, seuraava_huolto, huollettu, huoltovali_vuosina) VALUES (40003, 'Vesiventtiili', 'Alfa-Laval', 'LKB-F', 63, 300004, '2021-03-18', '2019-11-24', 3);
INSERT INTO public.venttiili (id, nimi, valmistaja, malli, koko, id_varastonimike, seuraava_huolto, huollettu, huoltovali_vuosina) VALUES (40005, 'Vesiventtiili', 'Alfa-Laval', 'LKB-F', 51, 300003, '2021-02-15', '2019-11-24', 3);
INSERT INTO public.venttiili (id, nimi, valmistaja, malli, koko, id_varastonimike, seuraava_huolto, huollettu, huoltovali_vuosina) VALUES (40007, 'Vesiventtiili', 'Alfa-Laval', 'LKB-F', 38, 300002, '2020-02-28', '2019-11-24', 3);
INSERT INTO public.venttiili (id, nimi, valmistaja, malli, koko, id_varastonimike, seuraava_huolto, huollettu, huoltovali_vuosina) VALUES (40009, 'Vesiventtiili', 'SPX', 'SW43', 76, 300010, '2020-09-15', '2019-11-24', 3);
INSERT INTO public.venttiili (id, nimi, valmistaja, malli, koko, id_varastonimike, seuraava_huolto, huollettu, huoltovali_vuosina) VALUES (40002, 'Tuoteventtiili', 'Alfa-Laval', 'Unique SSV', 63, 300006, '2021-02-15', '2019-11-24', 3);
INSERT INTO public.venttiili (id, nimi, valmistaja, malli, koko, id_varastonimike, seuraava_huolto, huollettu, huoltovali_vuosina) VALUES (40004, 'Pesuventtiili', 'SPX', 'SW43', 51, 300008, '2021-02-15', '2019-11-24', 3);
INSERT INTO public.venttiili (id, nimi, valmistaja, malli, koko, id_varastonimike, seuraava_huolto, huollettu, huoltovali_vuosina) VALUES (40006, 'Tuoteventtiili', 'Alfa-Laval', 'Unique SSV', 76, 300007, '2020-04-25', '2019-11-24', 3);
INSERT INTO public.venttiili (id, nimi, valmistaja, malli, koko, id_varastonimike, seuraava_huolto, huollettu, huoltovali_vuosina) VALUES (40008, 'Tuoteventtiili', 'Alfa-Laval', 'Unique SSV', 51, 300005, '2020-04-11', '2019-11-24', 3);
INSERT INTO public.venttiili (id, nimi, valmistaja, malli, koko, id_varastonimike, seuraava_huolto, huollettu, huoltovali_vuosina) VALUES (40010, 'Pesuventtiili', 'SPX', 'SW43', 63, 300009, '2020-02-03', '2019-11-24', 3);


--
-- TOC entry 2019 (class 2606 OID 16601)
-- Name: huollot Huollot_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.huollot
    ADD CONSTRAINT "Huollot_pkey" PRIMARY KEY ("ID");


--
-- TOC entry 2023 (class 2606 OID 16623)
-- Name: ostot Ostot_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.ostot
    ADD CONSTRAINT "Ostot_pkey" PRIMARY KEY ("ID");


--
-- TOC entry 2016 (class 2606 OID 16590)
-- Name: venttiili Venttiili_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.venttiili
    ADD CONSTRAINT "Venttiili_pkey" PRIMARY KEY (id);


--
-- TOC entry 2014 (class 2606 OID 16582)
-- Name: varastonimike varastoNimike_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.varastonimike
    ADD CONSTRAINT "varastoNimike_pkey" PRIMARY KEY (id);


--
-- TOC entry 2020 (class 1259 OID 16618)
-- Name: fki_Nimike; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_Nimike" ON public.huollot USING btree ("id_varastoNimike");


--
-- TOC entry 2024 (class 1259 OID 16629)
-- Name: fki_VNimike; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_VNimike" ON public.ostot USING btree ("id_Varastonimike");


--
-- TOC entry 2017 (class 1259 OID 16596)
-- Name: fki_Varastonimike; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_Varastonimike" ON public.venttiili USING btree (id_varastonimike);


--
-- TOC entry 2021 (class 1259 OID 16607)
-- Name: fki_venttiili; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_venttiili ON public.huollot USING btree (id_venttiili);


--
-- TOC entry 2028 (class 2606 OID 16613)
-- Name: huollot Nimike; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.huollot
    ADD CONSTRAINT "Nimike" FOREIGN KEY ("id_varastoNimike") REFERENCES public.varastonimike(id);


--
-- TOC entry 2029 (class 2606 OID 16624)
-- Name: ostot VNimike; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.ostot
    ADD CONSTRAINT "VNimike" FOREIGN KEY ("id_Varastonimike") REFERENCES public.varastonimike(id);


--
-- TOC entry 2025 (class 2606 OID 16591)
-- Name: venttiili Varastonimike; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.venttiili
    ADD CONSTRAINT "Varastonimike" FOREIGN KEY (id_varastonimike) REFERENCES public.varastonimike(id);


--
-- TOC entry 2027 (class 2606 OID 16608)
-- Name: huollot Varastonimike; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.huollot
    ADD CONSTRAINT "Varastonimike" FOREIGN KEY ("id_varastoNimike") REFERENCES public.varastonimike(id);


--
-- TOC entry 2026 (class 2606 OID 16602)
-- Name: huollot venttiili; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.huollot
    ADD CONSTRAINT venttiili FOREIGN KEY (id_venttiili) REFERENCES public.venttiili(id);


-- Completed on 2019-12-05 18:43:05

--
-- PostgreSQL database dump complete
--
