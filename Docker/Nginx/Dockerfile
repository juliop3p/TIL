FROM nginx:1.21.6-alpine

#configuration

COPY ./nginx.conf /etc/nginx/nginx.conf

#content, comment out the ones you dont need!

# creating the same structure of the project
RUN mkdir -p /usr/share/nginx/html/app
RUN mkdir -p /usr/share/nginx/html/app/js
RUN mkdir -p /usr/share/nginx/html/app/css

# moving my files to the nginx folder following the same structure of the project
COPY ./app/*.html /usr/share/nginx/html/app
COPY ./app/css/*.css /usr/share/nginx/html/app/css
COPY ./app/js/*.js /usr/share/nginx/html/app/js
