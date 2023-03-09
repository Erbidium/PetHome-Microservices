FROM node:18-alpine
 
WORKDIR /user/src/app
 
COPY . .
 
RUN npm ci --omit=dev
 
RUN npm run build

USER node

EXPOSE 8080

CMD ["npm", "run", "start:prod"]