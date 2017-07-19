#! /bin/sh
# Load data in plain text files to tables
# Written by Li Yang

for f in product pc laptop printer
do
 echo "Loading $f"
 mysql --local-infile computer -e "load data local infile '$f.txt' into table $f columns terminated by ',' optionally enclosed by '\"' lines terminated by '\n'"
done

for f in classes ships battles outcomes
do
 echo "Loading $f"
 mysql --local-infile battleship -e "load data local infile '$f.txt' into table $f columns terminated by ',' optionally enclosed by '\"' lines terminated by '\n'"
done

for f in suppliers parts catalog 
do
 echo "Loading $f"
 mysql --local-infile catalog -e "load data local infile '$f.txt' into table $f columns terminated by ',' optionally enclosed by '\"' lines terminated by '\n'"
done

for f in emp dept works 
do
 echo "Loading $f"
 mysql --local-infile company -e "load data local infile '$f.txt' into table $f columns terminated by ',' optionally enclosed by '\"' lines terminated by '\n'"
done

for f in student faculty class enrolled 
do
 echo "Loading $f"
 mysql --local-infile university -e "load data local infile '$f.txt' into table $f columns terminated by ',' optionally enclosed by '\"' lines terminated by '\n'"
done

for f in flights aircraft employees certified
do
 echo "Loading $f"
 mysql --local-infile flights -e "load data local infile '$f.txt' into table $f columns terminated by ',' optionally enclosed by '\"' lines terminated by '\n'"
done

