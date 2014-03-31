--
-- PostgreSQL database dump
--

-- Dumped from database version 9.3.4
-- Dumped by pg_dump version 9.3.4
-- Started on 2014-03-31 10:29:25

SET statement_timeout = 0;
SET lock_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SET check_function_bodies = false;
SET client_min_messages = warning;

--
-- TOC entry 180 (class 3079 OID 11750)
-- Name: plpgsql; Type: EXTENSION; Schema: -; Owner: 
--

CREATE EXTENSION IF NOT EXISTS plpgsql WITH SCHEMA pg_catalog;


--
-- TOC entry 2012 (class 0 OID 0)
-- Dependencies: 180
-- Name: EXTENSION plpgsql; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION plpgsql IS 'PL/pgSQL procedural language';


SET search_path = public, pg_catalog;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- TOC entry 171 (class 1259 OID 16401)
-- Name: award; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE award (
    year integer NOT NULL,
    name character varying(50) NOT NULL,
    title character varying(50) NOT NULL,
    date date NOT NULL
);


ALTER TABLE public.award OWNER TO postgres;

--
-- TOC entry 172 (class 1259 OID 16406)
-- Name: genre; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE genre (
    name character varying(50) NOT NULL
);


ALTER TABLE public.genre OWNER TO postgres;

--
-- TOC entry 174 (class 1259 OID 16436)
-- Name: genreMovie; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE "genreMovie" (
    name character varying(50) NOT NULL,
    title character varying(50) NOT NULL,
    date date NOT NULL
);


ALTER TABLE public."genreMovie" OWNER TO postgres;

--
-- TOC entry 173 (class 1259 OID 16431)
-- Name: movie; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE movie (
    title character varying(50) NOT NULL,
    date date NOT NULL,
    language character varying(50)
);


ALTER TABLE public.movie OWNER TO postgres;

--
-- TOC entry 178 (class 1259 OID 16501)
-- Name: participates; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE participates (
    title character varying(50) NOT NULL,
    date date NOT NULL,
    rolename character varying(50) NOT NULL,
    id integer NOT NULL
);


ALTER TABLE public.participates OWNER TO postgres;

--
-- TOC entry 177 (class 1259 OID 16496)
-- Name: person; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE person (
    id integer NOT NULL,
    birthdate date NOT NULL,
    firstname character varying(50) NOT NULL,
    lastname character varying(50) NOT NULL,
    dateofdeath date NOT NULL,
    sex character(1) NOT NULL
);


ALTER TABLE public.person OWNER TO postgres;

--
-- TOC entry 175 (class 1259 OID 16461)
-- Name: refers; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE refers (
    title character varying(50) NOT NULL,
    date date NOT NULL,
    referredtitle character varying(50) NOT NULL,
    referreddate date NOT NULL
);


ALTER TABLE public.refers OWNER TO postgres;

--
-- TOC entry 179 (class 1259 OID 16531)
-- Name: review; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE review (
    id integer NOT NULL,
    rating integer,
    date date NOT NULL,
    username character varying(50) NOT NULL,
    title character varying(50) NOT NULL,
    "dateOfReview" date
);


ALTER TABLE public.review OWNER TO postgres;

--
-- TOC entry 176 (class 1259 OID 16476)
-- Name: role; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE role (
    rolename character varying(50) NOT NULL
);


ALTER TABLE public.role OWNER TO postgres;

--
-- TOC entry 170 (class 1259 OID 16394)
-- Name: user; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE "user" (
    username character varying(50) NOT NULL,
    email character varying(50) NOT NULL,
    password character varying(50) NOT NULL
);


ALTER TABLE public."user" OWNER TO postgres;

--
-- TOC entry 1996 (class 0 OID 16401)
-- Dependencies: 171
-- Data for Name: award; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY award (year, name, title, date) FROM stdin;
\.


--
-- TOC entry 1997 (class 0 OID 16406)
-- Dependencies: 172
-- Data for Name: genre; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY genre (name) FROM stdin;
\.


--
-- TOC entry 1999 (class 0 OID 16436)
-- Dependencies: 174
-- Data for Name: genreMovie; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY "genreMovie" (name, title, date) FROM stdin;
\.


--
-- TOC entry 1998 (class 0 OID 16431)
-- Dependencies: 173
-- Data for Name: movie; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY movie (title, date, language) FROM stdin;
\.


--
-- TOC entry 2003 (class 0 OID 16501)
-- Dependencies: 178
-- Data for Name: participates; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY participates (title, date, rolename, id) FROM stdin;
\.


--
-- TOC entry 2002 (class 0 OID 16496)
-- Dependencies: 177
-- Data for Name: person; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY person (id, birthdate, firstname, lastname, dateofdeath, sex) FROM stdin;
\.


--
-- TOC entry 2000 (class 0 OID 16461)
-- Dependencies: 175
-- Data for Name: refers; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY refers (title, date, referredtitle, referreddate) FROM stdin;
\.


--
-- TOC entry 2004 (class 0 OID 16531)
-- Dependencies: 179
-- Data for Name: review; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY review (id, rating, date, username, title, "dateOfReview") FROM stdin;
\.


--
-- TOC entry 2001 (class 0 OID 16476)
-- Dependencies: 176
-- Data for Name: role; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY role (rolename) FROM stdin;
\.


--
-- TOC entry 1995 (class 0 OID 16394)
-- Dependencies: 170
-- Data for Name: user; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY "user" (username, email, password) FROM stdin;
\.


--
-- TOC entry 1862 (class 2606 OID 16405)
-- Name: award_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY award
    ADD CONSTRAINT award_pkey PRIMARY KEY (year, name);


--
-- TOC entry 1868 (class 2606 OID 16440)
-- Name: genreMovie_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY "genreMovie"
    ADD CONSTRAINT "genreMovie_pkey" PRIMARY KEY (name, title, date);


--
-- TOC entry 1864 (class 2606 OID 16410)
-- Name: genre_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY genre
    ADD CONSTRAINT genre_pkey PRIMARY KEY (name);


--
-- TOC entry 1866 (class 2606 OID 16435)
-- Name: movie_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY movie
    ADD CONSTRAINT movie_pkey PRIMARY KEY (title, date);


--
-- TOC entry 1876 (class 2606 OID 16505)
-- Name: participates_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY participates
    ADD CONSTRAINT participates_pkey PRIMARY KEY (title, date, rolename, id);


--
-- TOC entry 1874 (class 2606 OID 16500)
-- Name: person_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY person
    ADD CONSTRAINT person_pkey PRIMARY KEY (id);


--
-- TOC entry 1870 (class 2606 OID 16465)
-- Name: refers_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY refers
    ADD CONSTRAINT refers_pkey PRIMARY KEY (title, date, referredtitle, referreddate);


--
-- TOC entry 1878 (class 2606 OID 16535)
-- Name: review_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY review
    ADD CONSTRAINT review_pkey PRIMARY KEY (id);


--
-- TOC entry 1872 (class 2606 OID 16480)
-- Name: role_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY role
    ADD CONSTRAINT role_pkey PRIMARY KEY (rolename);


--
-- TOC entry 1858 (class 2606 OID 16400)
-- Name: user_email_key; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY "user"
    ADD CONSTRAINT user_email_key UNIQUE (email);


--
-- TOC entry 1860 (class 2606 OID 16398)
-- Name: user_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY "user"
    ADD CONSTRAINT user_pkey PRIMARY KEY (username);


--
-- TOC entry 1879 (class 2606 OID 16441)
-- Name: genreMovie_name_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "genreMovie"
    ADD CONSTRAINT "genreMovie_name_fkey" FOREIGN KEY (name) REFERENCES genre(name);


--
-- TOC entry 1880 (class 2606 OID 16446)
-- Name: genreMovie_title_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "genreMovie"
    ADD CONSTRAINT "genreMovie_title_fkey" FOREIGN KEY (title, date) REFERENCES movie(title, date);


--
-- TOC entry 1885 (class 2606 OID 16516)
-- Name: participates_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY participates
    ADD CONSTRAINT participates_id_fkey FOREIGN KEY (id) REFERENCES person(id);


--
-- TOC entry 1884 (class 2606 OID 16511)
-- Name: participates_rolename_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY participates
    ADD CONSTRAINT participates_rolename_fkey FOREIGN KEY (rolename) REFERENCES role(rolename);


--
-- TOC entry 1883 (class 2606 OID 16506)
-- Name: participates_title_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY participates
    ADD CONSTRAINT participates_title_fkey FOREIGN KEY (title, date) REFERENCES movie(title, date);


--
-- TOC entry 1882 (class 2606 OID 16471)
-- Name: refers_referredtitle_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY refers
    ADD CONSTRAINT refers_referredtitle_fkey FOREIGN KEY (referredtitle, referreddate) REFERENCES movie(title, date);


--
-- TOC entry 1881 (class 2606 OID 16466)
-- Name: refers_title_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY refers
    ADD CONSTRAINT refers_title_fkey FOREIGN KEY (title, date) REFERENCES movie(title, date);


--
-- TOC entry 1887 (class 2606 OID 16541)
-- Name: review_title_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY review
    ADD CONSTRAINT review_title_fkey FOREIGN KEY (title, date) REFERENCES movie(title, date);


--
-- TOC entry 1886 (class 2606 OID 16536)
-- Name: review_username_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY review
    ADD CONSTRAINT review_username_fkey FOREIGN KEY (username) REFERENCES "user"(username);


--
-- TOC entry 2011 (class 0 OID 0)
-- Dependencies: 5
-- Name: public; Type: ACL; Schema: -; Owner: postgres
--

REVOKE ALL ON SCHEMA public FROM PUBLIC;
REVOKE ALL ON SCHEMA public FROM postgres;
GRANT ALL ON SCHEMA public TO postgres;
GRANT ALL ON SCHEMA public TO PUBLIC;


-- Completed on 2014-03-31 10:29:26

--
-- PostgreSQL database dump complete
--

