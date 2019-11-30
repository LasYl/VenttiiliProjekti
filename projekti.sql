--
-- PostgreSQL database dump
--

-- Dumped from database version 9.6.15
-- Dumped by pg_dump version 9.6.15

-- Started on 2019-11-30 17:24:25

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
-- TOC entry 185 (class 1259 OID 16451)
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
-- TOC entry 186 (class 1259 OID 16454)
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
-- TOC entry 187 (class 1259 OID 16457)
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
-- TOC entry 188 (class 1259 OID 16463)
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
-- TOC entry 2147 (class 0 OID 16451)
-- Dependencies: 185
-- Data for Name: huollot; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.huollot ("ID", "id_varastoNimike", id_venttiili, "PVM") FROM stdin;
1	300001	40001	2018-11-13
2	300006	40002	2019-07-12
3	300002	40007	2019-07-12
4	300009	40010	2019-07-12
5	300008	40004	2019-08-19
\.


--
-- TOC entry 2148 (class 0 OID 16454)
-- Dependencies: 186
-- Data for Name: ostot; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.ostot ("ID", "id_Varastonimike", "PVM", "Määrä") FROM stdin;
1	300001	2018-12-29	2
2	300004	2019-02-01	2
3	300010	2019-05-04	2
4	300007	2019-08-11	2
5	300007	2019-08-22	1
6	300001	2019-10-21	1
\.


--
-- TOC entry 2149 (class 0 OID 16457)
-- Dependencies: 187
-- Data for Name: varastonimike; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.varastonimike (id, nimi, valmistaja, "myyjä", hinta, saldo, minimisaldo) FROM stdin;
300001	LKB-F 25	Alfa-Laval	TetraPak	70	2	2
300002	LKB-F 38	Alfa-Laval	TetraPak	95	2	2
300003	LKB-F 51	Alfa-Laval	TetraPak	105	2	2
300004	LKB-F 63	Alfa-Laval	TetraPak	120	2	2
300005	Unique SSV 51	Alfa-Laval	TetraPak	95	2	2
300006	Unique SSV 63	Alfa-Laval	TetraPak	105	2	2
300007	Unique SSV 76	Alfa-Laval	TetraPak	120	2	2
300008	SW43 51	SPX	Flow Serve	95	2	2
300009	SW43 63	SPX	Flow Serve	105	2	2
300010	SW43 76	SPX	Flow Serve	120	2	2
\.


--
-- TOC entry 2150 (class 0 OID 16463)
-- Dependencies: 188
-- Data for Name: venttiili; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.venttiili (id, nimi, valmistaja, malli, koko, id_varastonimike, seuraava_huolto, huollettu, huoltovali_vuosina) FROM stdin;
40003	Vesiventtiili	Alfa-Laval	LKB-F	63	300004	2021-03-18	2019-11-24	3
40005	Vesiventtiili	Alfa-Laval	LKB-F	51	300003	2021-02-15	2019-11-24	3
40008	Vesiventtiili	Alfa-Laval	Unique SSV	51	300005	2020-04-11	2019-11-24	3
40009	Vesiventtiili	SPX	SW43	76	300010	2020-09-15	2019-11-24	3
40001	Tuoteventtiili	Alfa-Laval	LKB-F	25	300001	2020-11-20	2019-11-24	3
40002	Pesuventtiili	Alfa-Laval	Unique SSV	63	300006	2021-02-15	2019-11-24	3
40004	Tuoteventtiili	SPX	SW43	51	300008	2021-02-15	2019-11-24	3
40006	Tuoteventtiili	Alfa-Laval	Unique SSV	76	300007	2020-04-25	2019-11-24	3
40007	Pesuventtiili	Alfa-Laval	LKB-F	38	300002	2020-02-28	2019-11-24	3
40010	Pesuventtiili	SPX	SW43	63	300009	2020-02-03	2019-11-24	3
\.


--
-- TOC entry 2014 (class 2606 OID 16470)
-- Name: huollot Huollot_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.huollot
    ADD CONSTRAINT "Huollot_pkey" PRIMARY KEY ("ID");


--
-- TOC entry 2018 (class 2606 OID 16472)
-- Name: ostot Ostot_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.ostot
    ADD CONSTRAINT "Ostot_pkey" PRIMARY KEY ("ID");


--
-- TOC entry 2023 (class 2606 OID 16474)
-- Name: venttiili Venttiili_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.venttiili
    ADD CONSTRAINT "Venttiili_pkey" PRIMARY KEY (id);


--
-- TOC entry 2021 (class 2606 OID 16476)
-- Name: varastonimike varastoNimike_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.varastonimike
    ADD CONSTRAINT "varastoNimike_pkey" PRIMARY KEY (id);


--
-- TOC entry 2015 (class 1259 OID 16477)
-- Name: fki_Nimike; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_Nimike" ON public.huollot USING btree ("id_varastoNimike");


--
-- TOC entry 2019 (class 1259 OID 16478)
-- Name: fki_VNimike; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_VNimike" ON public.ostot USING btree ("id_Varastonimike");


--
-- TOC entry 2024 (class 1259 OID 16479)
-- Name: fki_Varastonimike; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_Varastonimike" ON public.venttiili USING btree (id_varastonimike);


--
-- TOC entry 2016 (class 1259 OID 16480)
-- Name: fki_venttiili; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_venttiili ON public.huollot USING btree (id_venttiili);


--
-- TOC entry 2025 (class 2606 OID 16481)
-- Name: huollot Nimike; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.huollot
    ADD CONSTRAINT "Nimike" FOREIGN KEY ("id_varastoNimike") REFERENCES public.varastonimike(id);


--
-- TOC entry 2028 (class 2606 OID 16486)
-- Name: ostot VNimike; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.ostot
    ADD CONSTRAINT "VNimike" FOREIGN KEY ("id_Varastonimike") REFERENCES public.varastonimike(id);


--
-- TOC entry 2029 (class 2606 OID 16491)
-- Name: venttiili Varastonimike; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.venttiili
    ADD CONSTRAINT "Varastonimike" FOREIGN KEY (id_varastonimike) REFERENCES public.varastonimike(id);


--
-- TOC entry 2026 (class 2606 OID 16496)
-- Name: huollot Varastonimike; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.huollot
    ADD CONSTRAINT "Varastonimike" FOREIGN KEY ("id_varastoNimike") REFERENCES public.varastonimike(id);


--
-- TOC entry 2027 (class 2606 OID 16501)
-- Name: huollot venttiili; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.huollot
    ADD CONSTRAINT venttiili FOREIGN KEY (id_venttiili) REFERENCES public.venttiili(id);


-- Completed on 2019-11-30 17:24:26

--
-- PostgreSQL database dump complete
--

