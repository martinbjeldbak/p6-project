PGDMP         2    	            r           ourimdb    9.3.4    9.3.4 0    �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                       false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                       false            �           1262    16393    ourimdb    DATABASE     �   CREATE DATABASE ourimdb WITH TEMPLATE = template0 ENCODING = 'UTF8' LC_COLLATE = 'Danish_Denmark.1252' LC_CTYPE = 'Danish_Denmark.1252';
    DROP DATABASE ourimdb;
             postgres    false                        2615    2200    public    SCHEMA        CREATE SCHEMA public;
    DROP SCHEMA public;
             postgres    false            �           0    0    SCHEMA public    COMMENT     6   COMMENT ON SCHEMA public IS 'standard public schema';
                  postgres    false    5            �           0    0    public    ACL     �   REVOKE ALL ON SCHEMA public FROM PUBLIC;
REVOKE ALL ON SCHEMA public FROM postgres;
GRANT ALL ON SCHEMA public TO postgres;
GRANT ALL ON SCHEMA public TO PUBLIC;
                  postgres    false    5            �            3079    11750    plpgsql 	   EXTENSION     ?   CREATE EXTENSION IF NOT EXISTS plpgsql WITH SCHEMA pg_catalog;
    DROP EXTENSION plpgsql;
                  false            �           0    0    EXTENSION plpgsql    COMMENT     @   COMMENT ON EXTENSION plpgsql IS 'PL/pgSQL procedural language';
                       false    180            �            1259    16401    award    TABLE     �   CREATE TABLE award (
    year integer NOT NULL,
    name character varying(50) NOT NULL,
    title character varying(50) NOT NULL,
    date date NOT NULL
);
    DROP TABLE public.award;
       public         postgres    false    5            �            1259    16406    genre    TABLE     @   CREATE TABLE genre (
    name character varying(50) NOT NULL
);
    DROP TABLE public.genre;
       public         postgres    false    5            �            1259    16436 
   genreMovie    TABLE     �   CREATE TABLE "genreMovie" (
    name character varying(50) NOT NULL,
    title character varying(50) NOT NULL,
    date date NOT NULL
);
     DROP TABLE public."genreMovie";
       public         postgres    false    5            �            1259    16431    movie    TABLE     }   CREATE TABLE movie (
    title character varying(50) NOT NULL,
    date date NOT NULL,
    language character varying(50)
);
    DROP TABLE public.movie;
       public         postgres    false    5            �            1259    16501    participates    TABLE     �   CREATE TABLE participates (
    title character varying(50) NOT NULL,
    date date NOT NULL,
    rolename character varying(50) NOT NULL,
    id integer NOT NULL
);
     DROP TABLE public.participates;
       public         postgres    false    5            �            1259    16496    person    TABLE     �   CREATE TABLE person (
    id integer NOT NULL,
    birthdate date NOT NULL,
    firstname character varying(50) NOT NULL,
    lastname character varying(50) NOT NULL,
    dateofdeath date NOT NULL,
    sex character(1) NOT NULL
);
    DROP TABLE public.person;
       public         postgres    false    5            �            1259    16461    refers    TABLE     �   CREATE TABLE refers (
    title character varying(50) NOT NULL,
    date date NOT NULL,
    referredtitle character varying(50) NOT NULL,
    referreddate date NOT NULL
);
    DROP TABLE public.refers;
       public         postgres    false    5            �            1259    16531    review    TABLE     �   CREATE TABLE review (
    id integer NOT NULL,
    rating integer,
    date date NOT NULL,
    username character varying(50) NOT NULL,
    title character varying(50) NOT NULL
);
    DROP TABLE public.review;
       public         postgres    false    5            �            1259    16476    role    TABLE     C   CREATE TABLE role (
    rolename character varying(50) NOT NULL
);
    DROP TABLE public.role;
       public         postgres    false    5            �            1259    16394    user    TABLE     �   CREATE TABLE "user" (
    username character varying(50) NOT NULL,
    email character varying(50) NOT NULL,
    password character varying(50) NOT NULL
);
    DROP TABLE public."user";
       public         postgres    false    5            �          0    16401    award 
   TABLE DATA               1   COPY award (year, name, title, date) FROM stdin;
    public       postgres    false    171   �3       �          0    16406    genre 
   TABLE DATA                  COPY genre (name) FROM stdin;
    public       postgres    false    172   �3       �          0    16436 
   genreMovie 
   TABLE DATA               2   COPY "genreMovie" (name, title, date) FROM stdin;
    public       postgres    false    174   �3       �          0    16431    movie 
   TABLE DATA               /   COPY movie (title, date, language) FROM stdin;
    public       postgres    false    173   4       �          0    16501    participates 
   TABLE DATA               :   COPY participates (title, date, rolename, id) FROM stdin;
    public       postgres    false    178   /4       �          0    16496    person 
   TABLE DATA               O   COPY person (id, birthdate, firstname, lastname, dateofdeath, sex) FROM stdin;
    public       postgres    false    177   L4       �          0    16461    refers 
   TABLE DATA               C   COPY refers (title, date, referredtitle, referreddate) FROM stdin;
    public       postgres    false    175   i4       �          0    16531    review 
   TABLE DATA               <   COPY review (id, rating, date, username, title) FROM stdin;
    public       postgres    false    179   �4       �          0    16476    role 
   TABLE DATA               !   COPY role (rolename) FROM stdin;
    public       postgres    false    176   �4       �          0    16394    user 
   TABLE DATA               4   COPY "user" (username, email, password) FROM stdin;
    public       postgres    false    170   �4       F           2606    16405 
   award_pkey 
   CONSTRAINT     O   ALTER TABLE ONLY award
    ADD CONSTRAINT award_pkey PRIMARY KEY (year, name);
 :   ALTER TABLE ONLY public.award DROP CONSTRAINT award_pkey;
       public         postgres    false    171    171    171            L           2606    16440    genreMovie_pkey 
   CONSTRAINT     d   ALTER TABLE ONLY "genreMovie"
    ADD CONSTRAINT "genreMovie_pkey" PRIMARY KEY (name, title, date);
 H   ALTER TABLE ONLY public."genreMovie" DROP CONSTRAINT "genreMovie_pkey";
       public         postgres    false    174    174    174    174            H           2606    16410 
   genre_pkey 
   CONSTRAINT     I   ALTER TABLE ONLY genre
    ADD CONSTRAINT genre_pkey PRIMARY KEY (name);
 :   ALTER TABLE ONLY public.genre DROP CONSTRAINT genre_pkey;
       public         postgres    false    172    172            J           2606    16435 
   movie_pkey 
   CONSTRAINT     P   ALTER TABLE ONLY movie
    ADD CONSTRAINT movie_pkey PRIMARY KEY (title, date);
 :   ALTER TABLE ONLY public.movie DROP CONSTRAINT movie_pkey;
       public         postgres    false    173    173    173            T           2606    16505    participates_pkey 
   CONSTRAINT     l   ALTER TABLE ONLY participates
    ADD CONSTRAINT participates_pkey PRIMARY KEY (title, date, rolename, id);
 H   ALTER TABLE ONLY public.participates DROP CONSTRAINT participates_pkey;
       public         postgres    false    178    178    178    178    178            R           2606    16500    person_pkey 
   CONSTRAINT     I   ALTER TABLE ONLY person
    ADD CONSTRAINT person_pkey PRIMARY KEY (id);
 <   ALTER TABLE ONLY public.person DROP CONSTRAINT person_pkey;
       public         postgres    false    177    177            N           2606    16465    refers_pkey 
   CONSTRAINT     o   ALTER TABLE ONLY refers
    ADD CONSTRAINT refers_pkey PRIMARY KEY (title, date, referredtitle, referreddate);
 <   ALTER TABLE ONLY public.refers DROP CONSTRAINT refers_pkey;
       public         postgres    false    175    175    175    175    175            V           2606    16535    review_pkey 
   CONSTRAINT     I   ALTER TABLE ONLY review
    ADD CONSTRAINT review_pkey PRIMARY KEY (id);
 <   ALTER TABLE ONLY public.review DROP CONSTRAINT review_pkey;
       public         postgres    false    179    179            P           2606    16480 	   role_pkey 
   CONSTRAINT     K   ALTER TABLE ONLY role
    ADD CONSTRAINT role_pkey PRIMARY KEY (rolename);
 8   ALTER TABLE ONLY public.role DROP CONSTRAINT role_pkey;
       public         postgres    false    176    176            B           2606    16400    user_email_key 
   CONSTRAINT     J   ALTER TABLE ONLY "user"
    ADD CONSTRAINT user_email_key UNIQUE (email);
 ?   ALTER TABLE ONLY public."user" DROP CONSTRAINT user_email_key;
       public         postgres    false    170    170            D           2606    16398 	   user_pkey 
   CONSTRAINT     M   ALTER TABLE ONLY "user"
    ADD CONSTRAINT user_pkey PRIMARY KEY (username);
 :   ALTER TABLE ONLY public."user" DROP CONSTRAINT user_pkey;
       public         postgres    false    170    170            W           2606    16441    genreMovie_name_fkey    FK CONSTRAINT     s   ALTER TABLE ONLY "genreMovie"
    ADD CONSTRAINT "genreMovie_name_fkey" FOREIGN KEY (name) REFERENCES genre(name);
 M   ALTER TABLE ONLY public."genreMovie" DROP CONSTRAINT "genreMovie_name_fkey";
       public       postgres    false    172    1864    174            X           2606    16446    genreMovie_title_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY "genreMovie"
    ADD CONSTRAINT "genreMovie_title_fkey" FOREIGN KEY (title, date) REFERENCES movie(title, date);
 N   ALTER TABLE ONLY public."genreMovie" DROP CONSTRAINT "genreMovie_title_fkey";
       public       postgres    false    1866    174    174    173    173            ]           2606    16516    participates_id_fkey    FK CONSTRAINT     n   ALTER TABLE ONLY participates
    ADD CONSTRAINT participates_id_fkey FOREIGN KEY (id) REFERENCES person(id);
 K   ALTER TABLE ONLY public.participates DROP CONSTRAINT participates_id_fkey;
       public       postgres    false    1874    178    177            \           2606    16511    participates_rolename_fkey    FK CONSTRAINT     ~   ALTER TABLE ONLY participates
    ADD CONSTRAINT participates_rolename_fkey FOREIGN KEY (rolename) REFERENCES role(rolename);
 Q   ALTER TABLE ONLY public.participates DROP CONSTRAINT participates_rolename_fkey;
       public       postgres    false    176    178    1872            [           2606    16506    participates_title_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY participates
    ADD CONSTRAINT participates_title_fkey FOREIGN KEY (title, date) REFERENCES movie(title, date);
 N   ALTER TABLE ONLY public.participates DROP CONSTRAINT participates_title_fkey;
       public       postgres    false    178    178    173    173    1866            Z           2606    16471    refers_referredtitle_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY refers
    ADD CONSTRAINT refers_referredtitle_fkey FOREIGN KEY (referredtitle, referreddate) REFERENCES movie(title, date);
 J   ALTER TABLE ONLY public.refers DROP CONSTRAINT refers_referredtitle_fkey;
       public       postgres    false    173    175    173    1866    175            Y           2606    16466    refers_title_fkey    FK CONSTRAINT     v   ALTER TABLE ONLY refers
    ADD CONSTRAINT refers_title_fkey FOREIGN KEY (title, date) REFERENCES movie(title, date);
 B   ALTER TABLE ONLY public.refers DROP CONSTRAINT refers_title_fkey;
       public       postgres    false    175    175    173    173    1866            _           2606    16541    review_title_fkey    FK CONSTRAINT     v   ALTER TABLE ONLY review
    ADD CONSTRAINT review_title_fkey FOREIGN KEY (title, date) REFERENCES movie(title, date);
 B   ALTER TABLE ONLY public.review DROP CONSTRAINT review_title_fkey;
       public       postgres    false    1866    179    173    173    179            ^           2606    16536    review_username_fkey    FK CONSTRAINT     t   ALTER TABLE ONLY review
    ADD CONSTRAINT review_username_fkey FOREIGN KEY (username) REFERENCES "user"(username);
 E   ALTER TABLE ONLY public.review DROP CONSTRAINT review_username_fkey;
       public       postgres    false    179    1860    170            �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �     