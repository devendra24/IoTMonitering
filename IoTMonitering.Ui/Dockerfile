FROM nginx:alpine

RUN rm -rf /usr/share/nginx/html/*
# Copy built Angular files from Stage 1
COPY ./dist/io-tmoniteriing.ui/browser /usr/share/nginx/html

# Start Nginx
CMD ["nginx", "-g", "daemon off;"]
