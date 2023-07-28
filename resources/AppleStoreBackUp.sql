PGDMP     '    4                {            apples-store-db    15.3    15.3 3    O           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            P           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            Q           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            R           1262    16835    apples-store-db    DATABASE     �   CREATE DATABASE "apples-store-db" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'English_United States.1252';
 !   DROP DATABASE "apples-store-db";
                postgres    false            �            1259    16837 
   categories    TABLE       CREATE TABLE public.categories (
    id bigint NOT NULL,
    name character varying(50) NOT NULL,
    image_path text NOT NULL,
    description text,
    created_at timestamp without time zone DEFAULT now(),
    updated_at timestamp without time zone DEFAULT now()
);
    DROP TABLE public.categories;
       public         heap    postgres    false            �            1259    16836    categories_id_seq    SEQUENCE     �   ALTER TABLE public.categories ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.categories_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    215            �            1259    16902 
   deliveries    TABLE       CREATE TABLE public.deliveries (
    id bigint NOT NULL,
    first_name character varying(50) NOT NULL,
    last_name character varying(50) NOT NULL,
    phone_number character varying(13) NOT NULL,
    passport_seria character varying(9),
    is_male boolean NOT NULL,
    birth_date date,
    region text,
    password_hash text NOT NULL,
    salt text NOT NULL,
    image_path text NOT NULL,
    created_at timestamp without time zone DEFAULT now(),
    updated_at timestamp without time zone DEFAULT now()
);
    DROP TABLE public.deliveries;
       public         heap    postgres    false            �            1259    16901    deliveries_id_seq    SEQUENCE     �   ALTER TABLE public.deliveries ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.deliveries_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    225            �            1259    16862 	   discounts    TABLE     �   CREATE TABLE public.discounts (
    id bigint NOT NULL,
    name character varying(50) NOT NULL,
    description text,
    created_at timestamp without time zone DEFAULT now(),
    updated_at timestamp without time zone DEFAULT now()
);
    DROP TABLE public.discounts;
       public         heap    postgres    false            �            1259    16861    discounts_id_seq    SEQUENCE     �   ALTER TABLE public.discounts ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.discounts_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    219            �            1259    16932    order_details    TABLE     �  CREATE TABLE public.order_details (
    id bigint NOT NULL,
    order_id bigint,
    product_id bigint,
    quantity integer NOT NULL,
    total_price double precision NOT NULL,
    discount_price double precision NOT NULL,
    result_price double precision NOT NULL,
    description text,
    created_at timestamp without time zone DEFAULT now(),
    updated_at timestamp without time zone DEFAULT now()
);
 !   DROP TABLE public.order_details;
       public         heap    postgres    false            �            1259    16931    order_details_id_seq    SEQUENCE     �   ALTER TABLE public.order_details ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.order_details_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    229            �            1259    16912    orders    TABLE     C  CREATE TABLE public.orders (
    id bigint NOT NULL,
    user_id bigint,
    delivery_id bigint,
    status text NOT NULL,
    delivery_price double precision NOT NULL,
    products_price double precision NOT NULL,
    total_price double precision NOT NULL,
    lattitude double precision NOT NULL,
    longtitude double precision NOT NULL,
    payment_type text NOT NULL,
    is_paid boolean NOT NULL,
    is_contracted boolean NOT NULL,
    description text,
    created_at timestamp without time zone DEFAULT now(),
    updated_at timestamp without time zone DEFAULT now()
);
    DROP TABLE public.orders;
       public         heap    postgres    false            �            1259    16911    orders_id_seq    SEQUENCE     �   ALTER TABLE public.orders ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.orders_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    227            �            1259    16872    product_discounts    TABLE     �  CREATE TABLE public.product_discounts (
    id bigint NOT NULL,
    product_id bigint,
    discount_id bigint,
    start_at timestamp without time zone NOT NULL,
    end_at timestamp without time zone NOT NULL,
    percentage smallint NOT NULL,
    description text,
    created_at timestamp without time zone DEFAULT now(),
    updated_at timestamp without time zone DEFAULT now()
);
 %   DROP TABLE public.product_discounts;
       public         heap    postgres    false            �            1259    16871    product_discounts_id_seq    SEQUENCE     �   ALTER TABLE public.product_discounts ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.product_discounts_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    221            �            1259    16847    products    TABLE     `  CREATE TABLE public.products (
    id bigint NOT NULL,
    category_id bigint,
    name character varying(50) NOT NULL,
    image_path text NOT NULL,
    color text NOT NULL,
    price double precision NOT NULL,
    description text,
    created_at timestamp without time zone DEFAULT now(),
    updated_at timestamp without time zone DEFAULT now()
);
    DROP TABLE public.products;
       public         heap    postgres    false            �            1259    16846    products_id_seq    SEQUENCE     �   ALTER TABLE public.products ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.products_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    217            �            1259    16892    users    TABLE       CREATE TABLE public.users (
    id bigint NOT NULL,
    first_name character varying(50) NOT NULL,
    last_name character varying(50) NOT NULL,
    phone_number character varying(13) NOT NULL,
    passport_seria character varying(9),
    is_male boolean NOT NULL,
    birth_date date,
    region text,
    password_hash text NOT NULL,
    salt text NOT NULL,
    image_path text NOT NULL,
    identity_role text NOT NULL,
    created_at timestamp without time zone DEFAULT now(),
    updated_at timestamp without time zone DEFAULT now()
);
    DROP TABLE public.users;
       public         heap    postgres    false            �            1259    16891    users_id_seq    SEQUENCE     �   ALTER TABLE public.users ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.users_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    223            >          0    16837 
   categories 
   TABLE DATA           _   COPY public.categories (id, name, image_path, description, created_at, updated_at) FROM stdin;
    public          postgres    false    215   WE       H          0    16902 
   deliveries 
   TABLE DATA           �   COPY public.deliveries (id, first_name, last_name, phone_number, passport_seria, is_male, birth_date, region, password_hash, salt, image_path, created_at, updated_at) FROM stdin;
    public          postgres    false    225    G       B          0    16862 	   discounts 
   TABLE DATA           R   COPY public.discounts (id, name, description, created_at, updated_at) FROM stdin;
    public          postgres    false    219   G       L          0    16932    order_details 
   TABLE DATA           �   COPY public.order_details (id, order_id, product_id, quantity, total_price, discount_price, result_price, description, created_at, updated_at) FROM stdin;
    public          postgres    false    229   :G       J          0    16912    orders 
   TABLE DATA           �   COPY public.orders (id, user_id, delivery_id, status, delivery_price, products_price, total_price, lattitude, longtitude, payment_type, is_paid, is_contracted, description, created_at, updated_at) FROM stdin;
    public          postgres    false    227   WG       D          0    16872    product_discounts 
   TABLE DATA           �   COPY public.product_discounts (id, product_id, discount_id, start_at, end_at, percentage, description, created_at, updated_at) FROM stdin;
    public          postgres    false    221   tG       @          0    16847    products 
   TABLE DATA           x   COPY public.products (id, category_id, name, image_path, color, price, description, created_at, updated_at) FROM stdin;
    public          postgres    false    217   �G       F          0    16892    users 
   TABLE DATA           �   COPY public.users (id, first_name, last_name, phone_number, passport_seria, is_male, birth_date, region, password_hash, salt, image_path, identity_role, created_at, updated_at) FROM stdin;
    public          postgres    false    223   �G       S           0    0    categories_id_seq    SEQUENCE SET     ?   SELECT pg_catalog.setval('public.categories_id_seq', 7, true);
          public          postgres    false    214            T           0    0    deliveries_id_seq    SEQUENCE SET     @   SELECT pg_catalog.setval('public.deliveries_id_seq', 1, false);
          public          postgres    false    224            U           0    0    discounts_id_seq    SEQUENCE SET     ?   SELECT pg_catalog.setval('public.discounts_id_seq', 1, false);
          public          postgres    false    218            V           0    0    order_details_id_seq    SEQUENCE SET     C   SELECT pg_catalog.setval('public.order_details_id_seq', 1, false);
          public          postgres    false    228            W           0    0    orders_id_seq    SEQUENCE SET     <   SELECT pg_catalog.setval('public.orders_id_seq', 1, false);
          public          postgres    false    226            X           0    0    product_discounts_id_seq    SEQUENCE SET     G   SELECT pg_catalog.setval('public.product_discounts_id_seq', 1, false);
          public          postgres    false    220            Y           0    0    products_id_seq    SEQUENCE SET     >   SELECT pg_catalog.setval('public.products_id_seq', 1, false);
          public          postgres    false    216            Z           0    0    users_id_seq    SEQUENCE SET     :   SELECT pg_catalog.setval('public.users_id_seq', 5, true);
          public          postgres    false    222            �           2606    16845    categories categories_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY public.categories
    ADD CONSTRAINT categories_pkey PRIMARY KEY (id);
 D   ALTER TABLE ONLY public.categories DROP CONSTRAINT categories_pkey;
       public            postgres    false    215            �           2606    16910    deliveries deliveries_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY public.deliveries
    ADD CONSTRAINT deliveries_pkey PRIMARY KEY (id);
 D   ALTER TABLE ONLY public.deliveries DROP CONSTRAINT deliveries_pkey;
       public            postgres    false    225            �           2606    16870    discounts discounts_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public.discounts
    ADD CONSTRAINT discounts_pkey PRIMARY KEY (id);
 B   ALTER TABLE ONLY public.discounts DROP CONSTRAINT discounts_pkey;
       public            postgres    false    219            �           2606    16940     order_details order_details_pkey 
   CONSTRAINT     ^   ALTER TABLE ONLY public.order_details
    ADD CONSTRAINT order_details_pkey PRIMARY KEY (id);
 J   ALTER TABLE ONLY public.order_details DROP CONSTRAINT order_details_pkey;
       public            postgres    false    229            �           2606    16920    orders orders_pkey 
   CONSTRAINT     P   ALTER TABLE ONLY public.orders
    ADD CONSTRAINT orders_pkey PRIMARY KEY (id);
 <   ALTER TABLE ONLY public.orders DROP CONSTRAINT orders_pkey;
       public            postgres    false    227            �           2606    16880 (   product_discounts product_discounts_pkey 
   CONSTRAINT     f   ALTER TABLE ONLY public.product_discounts
    ADD CONSTRAINT product_discounts_pkey PRIMARY KEY (id);
 R   ALTER TABLE ONLY public.product_discounts DROP CONSTRAINT product_discounts_pkey;
       public            postgres    false    221            �           2606    16855    products products_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public.products
    ADD CONSTRAINT products_pkey PRIMARY KEY (id);
 @   ALTER TABLE ONLY public.products DROP CONSTRAINT products_pkey;
       public            postgres    false    217            �           2606    16900    users users_pkey 
   CONSTRAINT     N   ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (id);
 :   ALTER TABLE ONLY public.users DROP CONSTRAINT users_pkey;
       public            postgres    false    223            �           2606    16941 )   order_details order_details_order_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.order_details
    ADD CONSTRAINT order_details_order_id_fkey FOREIGN KEY (order_id) REFERENCES public.orders(id);
 S   ALTER TABLE ONLY public.order_details DROP CONSTRAINT order_details_order_id_fkey;
       public          postgres    false    229    3237    227            �           2606    16946 +   order_details order_details_product_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.order_details
    ADD CONSTRAINT order_details_product_id_fkey FOREIGN KEY (product_id) REFERENCES public.products(id);
 U   ALTER TABLE ONLY public.order_details DROP CONSTRAINT order_details_product_id_fkey;
       public          postgres    false    217    3227    229            �           2606    16926    orders orders_delivery_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.orders
    ADD CONSTRAINT orders_delivery_id_fkey FOREIGN KEY (delivery_id) REFERENCES public.deliveries(id);
 H   ALTER TABLE ONLY public.orders DROP CONSTRAINT orders_delivery_id_fkey;
       public          postgres    false    225    227    3235            �           2606    16921    orders orders_user_id_fkey    FK CONSTRAINT     y   ALTER TABLE ONLY public.orders
    ADD CONSTRAINT orders_user_id_fkey FOREIGN KEY (user_id) REFERENCES public.users(id);
 D   ALTER TABLE ONLY public.orders DROP CONSTRAINT orders_user_id_fkey;
       public          postgres    false    223    3233    227            �           2606    16886 4   product_discounts product_discounts_discount_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.product_discounts
    ADD CONSTRAINT product_discounts_discount_id_fkey FOREIGN KEY (discount_id) REFERENCES public.discounts(id);
 ^   ALTER TABLE ONLY public.product_discounts DROP CONSTRAINT product_discounts_discount_id_fkey;
       public          postgres    false    3229    219    221            �           2606    16881 3   product_discounts product_discounts_product_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.product_discounts
    ADD CONSTRAINT product_discounts_product_id_fkey FOREIGN KEY (product_id) REFERENCES public.products(id);
 ]   ALTER TABLE ONLY public.product_discounts DROP CONSTRAINT product_discounts_product_id_fkey;
       public          postgres    false    217    3227    221            �           2606    16856 "   products products_category_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.products
    ADD CONSTRAINT products_category_id_fkey FOREIGN KEY (category_id) REFERENCES public.categories(id);
 L   ALTER TABLE ONLY public.products DROP CONSTRAINT products_category_id_fkey;
       public          postgres    false    217    3225    215            >   �  x���1��0Ek�� 9��\)�"@����ؖam��B�$k0;����t�����;I�����ɺ�~��͖Y@�(2
��Q���D���/oݗC]�U�{]�CZ��\����㰻\�2\���3�X�I==�8c41�Ȓ��6C���f�CʊH�B�VE�Z�vb��S~[�G=�	pv�x�B���yY~|�Cm�{��=pA%�xk՜2+�`D�Dq�)�ӟ�YӤF�,F���u�+���]G���f�m�y�j��/�xRF)���-�fn�����ǈz����u��pOR8h�)��z��lJ�=�T����z�,���d������S�K���O����{_YrP%)�Q�`M�?1Ej���}P��1`5��Z�n=�ߏ}����+      H      x������ � �      B      x������ � �      L      x������ � �      J      x������ � �      D      x������ � �      @      x������ � �      F   �  x�}ѹn�@�z�)���c�v�IAq`�M�@��eҠIɲ(HO"������b�oF���/�s�F�}��Ҝˁ|C�ȍ�1EHEc��B&�M8���S��?��m�l�ȩ�ߔ]�R۴�/p/7ê��_�y��f�$/T�5�R���KF3+ͱdc*ʌ>.�2C���U (�Fm�J�	kW�֑�կ}�XgR�g�����}_Mᴚ��ۢ���_$�*v[+���ݟ~&�Sz�"�*������R	��D�*˹Ä���
c�! ᛱ��W"O���u^��2�~f��������lݞN�)�ˢ�,a���O�h��vw׻D�������r���*��s��pj����d���"X !P�o�Q_��_��y�͡��     